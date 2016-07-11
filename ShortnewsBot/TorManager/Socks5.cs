using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace TorManager {
    class Socks5 {
        TorInstance _instance;
        Socket client;
        NetworkStream connection;

        public Socks5(TorInstance instance) {
            _instance = instance;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            client.ReceiveTimeout = client.SendTimeout = 10000;
            client.Connect(instance.Host, instance.Port);
            connection = new NetworkStream(client);
        }

        public bool Connected {
            get { return client != null && client.Connected; }
        }

        public bool Authenticate() {
            connection.WriteByte(5);
            connection.WriteByte(1);
            connection.WriteByte(0);
            byte[] resp = SocksResponse();
            return resp[0] == 5 && resp[1] == 0;
        }

        public byte Connect(string targetHost) {
            connection.WriteByte(5);
            connection.WriteByte(1);
            connection.WriteByte(0);
            connection.WriteByte(3);
            byte[] host = Encoding.ASCII.GetBytes(targetHost);
            connection.WriteByte((byte)host.Length);
            connection.Write(host, 0, host.Length);
            connection.WriteByte(0);
            connection.WriteByte(80);
            byte[] resp = SocksResponse();
            return resp[1];
        }

        private byte[] SocksResponse() {
            byte[] resp = new byte[2];
            connection.Read(resp, 0, resp.Length);
            return resp;
        }

        public void Send(string str, Encoding encoding) {
            byte[] data = encoding.GetBytes(str);
            connection.Write(data, 0, data.Length);
        }

        public void Send(string str) {
            Send(str, Encoding.UTF8);
        }

        public void Send(byte[] data) {
            connection.Write(data, 0, data.Length);
        }

        public string GetResponse() {
            int bytes = 0;
            byte[] buffer = new byte[client.ReceiveBufferSize];
            string resp = "";
            do {
                bytes = connection.Read(buffer, 0, buffer.Length);
                resp += Encoding.UTF8.GetString(buffer);
            } while (bytes > 0);

            while (!resp.StartsWith("HTTP") && resp.Contains("HTTP"))
                resp = resp.Substring(1);
            return resp;
        }
    }
}