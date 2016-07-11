using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Net.Sockets;

namespace TorManager {
    class TorInstance {
        string _host = "127.0.0.1";
        int _port;
        int controlPort;
        string _torPath;
        string _dataDir;
        Process tor;
        bool hasCircuit;
        int timeout = 10000;
        string torArgs = "";
        Socket client;
        bool authenticated;
        Socks5 socks;
        int socksConnections = 0;

        public delegate void Circuit(TorInstance instance);
        public event Circuit OnCircuit;

        public TorInstance(string host, int port, string torPath) {
            SetConstructor(host, port, torPath);
        }

        public TorInstance(int port, string torPath) {
            SetConstructor(null, port, torPath);
        }

        private void SetConstructor(string host, int port, string torPath) {
            _port = port;
            _torPath = torPath;
            _host = host == null ? _host : host;
        }

        public string Host {
            get { return _host; }
            set { _host = value; }
        }

        public int Port {
            get { return _port; }
            set { _port = value; }
        }

        public int ControlPort {
            get { return controlPort; }
            set { controlPort = value; }
        }

        public bool HasCircuit {
            get { return hasCircuit; }
        }

        public int Timeout {
            get { return timeout; }
            set { timeout = value; }
        }

        public Socks5 Socks {
            get { return socks; }
        }

        ~TorInstance() {
            try {
                tor.Kill();
            } catch (Exception) { }
        }

        public void Start() {
            CreateFolders();
            GenerateTorArgs();

            tor = new Process();
            tor.StartInfo.FileName = string.Format(@"{0}\tor.exe", _torPath);
            tor.StartInfo.Arguments = torArgs;
            tor.StartInfo.RedirectStandardOutput = true;
            tor.StartInfo.UseShellExecute = false;
            tor.StartInfo.CreateNoWindow = true;
            tor.Start();

            string line = "";
            while ((line = tor.StandardOutput.ReadLine()) != null) {
                Console.WriteLine(line);
                if (line.Contains("Tor has successfully opened a circuit")) {
                    DoOnCircuit();
                    break;
                }
                if (line.Contains("Address already in use")) 
                    throw new TorException(TorException.ExceptionType.PortInUse, string.Format("Port {0} bereits belegt", _port));
                
                if (line.Contains("failed to choose an exit server"))
                    throw new TorException(TorException.ExceptionType.NoServerAvaliable, "Kein Node verfügbar!");
            }
        }

        private void GenerateTorArgs() {
            if (controlPort == 0)
                controlPort = _port + 1;
            torArgs += string.Format("SocksBindAddress {0} SocksPort {1} ControlPort {2} DataDirectory \"{3}\" SocksTimeout {4}", _host, _port, controlPort,
                _dataDir, timeout);
            //torArgs += " CircuitBuildTimeout 5 KeepalivePeriod 60 NewCircuitPeriod 15 NumEntryGuards 2";
            //torArgs += " NumEntryGuards 1";
        }

        private void CreateFolders() {
            // torPath
            // --tor.exe
            // --data
            // ----9050
            if (_torPath.EndsWith("tor.exe"))
                _torPath = _torPath.Substring(0, _torPath.LastIndexOf("\\"));
            if (_torPath.EndsWith("\\"))
                _torPath = _torPath.Substring(0, _torPath.Length - 1);
            _dataDir = string.Format(@"{0}\data\{1}", _torPath, _port);
            if(!Directory.Exists(_dataDir))
                Directory.CreateDirectory(_dataDir);
        }

        private void DoOnCircuit() {
            hasCircuit = true;
            if (OnCircuit != null)
                OnCircuit(this);
        }

        public void SetAllowedNodes(string locations) {
            //ExitNodes {DE},{NL},{RO},{AT},{RU}
            torArgs += string.Format("{0} ExitNodes {1} ", (!torArgs.Contains("StrictNodes 1") ? "StrictNodes 1" : ""), locations);
        }

        public void SetExcludeNodes(string locations) {
            //ExcludeNodes {be},{pl},{ca},{za},{vn},{uz},{ua},{tw},{tr},{th}, {sk},{sg},{se},{sd},{fr},{ru}
            torArgs += string.Format("{0} ExcludeNodes {1} ", (!torArgs.Contains("StrictNodes 1") ? "StrictNodes 1" : ""), locations);
        }

        public string SendControlCmd(string cmd) {
            if (client == null || !client.Connected) {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(_host, controlPort); // exception: verbindung verweigert
                client.ReceiveTimeout = client.SendTimeout = timeout;
            }
            if (!authenticated)
                Authenticate();

            byte[] data = Encoding.UTF8.GetBytes(cmd);
            client.Send(data);
            return Receive();
        }

        private void Authenticate() {
            byte[] auth = Encoding.UTF8.GetBytes("AUTHENTICATE \"\"\r\n");
            client.Send(auth);
            string resp = Receive();
            authenticated = (resp == TorStatuscode.OK);
        }

        private string Receive() {
            byte[] buffer = new byte[4];
            string resp = "";
            do {
                client.Receive(buffer);
                resp += Encoding.UTF8.GetString(buffer);
            } while (!resp.EndsWith("\r\n"));
            return resp;
        }

        public bool NewCircuit() {
            string resp = SendControlCmd("SIGNAL NEWNYM \r\n");
            return (resp == TorStatuscode.OK);
        }

        public bool ConnectToSocks(string targetHost) {
            socks = new Socks5(this);

            if (socks.Authenticate()) {
                if(socks.Connect(targetHost) == 0)
                    return true;
            }
            socksConnections++;
            if (socksConnections <= 3) {
                NewCircuit();
                ConnectToSocks(targetHost);
            }
            return false;
        }

        public void Kill() {
            if (tor != null)
                tor.Kill();
        }

        public void KillAllTorProcesses() {
            Process.GetProcessesByName("tor").ToList().ForEach(process => {
                process.Kill();
            });
        }
    }
}