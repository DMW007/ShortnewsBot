using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TorManager;

namespace ShortnewsBot.ShortnewsAutomation {
    class ShortnewsVoter {
        List<NetworkCredential> accounts;
        string shortnewsUrl;
        TorInstance tor;
        RemoteWebDriver driver;

        public ShortnewsVoter(List<NetworkCredential> accounts, string shortnewsUrl, RemoteWebDriver driver = null) {
            this.accounts = accounts;
            this.shortnewsUrl = shortnewsUrl;
            this.driver = driver;
        }

        public void Start(bool useTor) {
            if(useTor) {
                tor = new TorInstance(9050, @"Tor\Tor");
                tor.OnCircuit += Tor_OnCircuit; ;
                tor.KillAllTorProcesses();
                tor.Start();

                var torSocksProfile = FirefoxDriverCreator.SetSocksProxy("127.0.0.1", 9050);
                driver = FirefoxDriverCreator.CreateFirefoxDriverWithAdblock(torSocksProfile);
            }else {
                if (driver == null)
                    driver = FirefoxDriverCreator.CreateFirefoxDriverWithAdblock();
                StartVoting();
            }
        }

        private void Tor_OnCircuit(TorInstance instance) {
            StartVoting();
        }

        void StartVoting() {
            accounts.ForEach(account => {
                LoginAccount(account);
                VoteShortnews(account);
                driver.Manage().Cookies.DeleteAllCookies();
            });
        }

        void VoteShortnews(NetworkCredential account) {
            driver.Navigate().GoToUrl(shortnewsUrl);
            ShortnewsTools.KillLeaveLayerIfPresent(driver);

            var positiveVoteButton = driver.FindElementByCssSelector("#rating-1-container .rating-button:first-child");
            positiveVoteButton.Click();
        }

        bool LoginAccount(NetworkCredential account) {
            driver.Navigate().GoToUrl("http://shortnews.de");
            driver.ExecuteScript("xaja_start_login();");
            ShortnewsTools.KillLeaveLayerIfPresent(driver);

            var userField = driver.FindElementById("xaja_login_username");
            userField.SendKeys(account.UserName);

            var passwordField = driver.FindElementById("xaja_login_password");
            passwordField.SendKeys(account.Password);

            driver.ExecuteScript("xaja_login_onclick()");
            return true;
        }
    }
}
