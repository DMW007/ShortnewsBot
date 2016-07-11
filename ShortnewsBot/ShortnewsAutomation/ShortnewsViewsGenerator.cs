using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorManager;

namespace ShortnewsBot.ShortnewsAutomation {
    class ShortnewsViewsGenerator {
        Random random = new Random();
        TorInstance tor;
        FirefoxDriver driver;
        string targetUrl;
        bool isRunning = true;
        int viewsCount = 0;

        public delegate void ViewsUpdating(int totalViewsCount);
        public event ViewsUpdating OnViewsUpdating;

        public ShortnewsViewsGenerator(string targetUrl) {
            this.targetUrl = targetUrl;
            // Selenium initialisieren
            var torSocksProfile = FirefoxDriverCreator.SetSocksProxy("127.0.0.1", 9050);
            driver = FirefoxDriverCreator.CreateFirefoxDriverWithAdblock(torSocksProfile);
            // Tor starten und auf einen Circuit warten
            tor = new TorInstance(9050, @"Tor\Tor");
            tor.OnCircuit += Tor_OnCircuit;
            tor.KillAllTorProcesses();
            tor.Start();
        }

        public void TriggerStop() {
            isRunning = false;
        }

        string GetCurrentPublicIp() {
            driver.Navigate().GoToUrl("http://checkip.dyndns.org/");
            var bodyHtml = driver.FindElementByTagName("body").Text;
            return bodyHtml.Replace("Current IP Address: ", "");
        }

        void Tor_OnCircuit(TorInstance instance) {
            var ip = GetCurrentPublicIp();
            
            while(isRunning) {
                driver.Navigate().GoToUrl(targetUrl);
                TriggerOnViewsUpdatingEvent();
                tor.NewCircuit();
            }
        }

        void TriggerOnViewsUpdatingEvent() {
            if (OnViewsUpdating != null)
                OnViewsUpdating(viewsCount++);
        }
    }
}
