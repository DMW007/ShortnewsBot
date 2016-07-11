using OpenQA.Selenium.Remote;
using ShortnewsBot.Config;
using ShortnewsBot.ShortnewsAutomation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace ShortnewsBot {
    public partial class MainForm : Form {
        RemoteWebDriver driver;
        ShortnewsViewsGenerator viewsGenerator;
        ShortnewsVoter voter; 

        public MainForm() {
            InitializeComponent();
            driver = FirefoxDriverCreator.CreateFirefoxDriverWithAdblock();
        }

        private void btnRegisterAccount_Click(object sender, EventArgs e) {
            new Thread((ThreadStart)delegate {
                var snRegister = new ShortnewsRegister(driver);
                var registerResult = snRegister.RegisterUser(tbMail.Text, tbUserName.Text);
                MessageBox.Show(registerResult.ToString());
            }).Start();
        }

        private void btnStartViewGenerator_Click(object sender, EventArgs e) {
            new Thread((ThreadStart)delegate {
                viewsGenerator = new ShortnewsViewsGenerator(tbShortnewsViewUrl.Text);
                viewsGenerator.OnViewsUpdating += delegate (int totalViewsCount) {
                    tsslViewsCount.Text = totalViewsCount.ToString();
                };
            }).Start();
            
        }

        private void btnStopViewGenerator_Click(object sender, EventArgs e) {
            if (viewsGenerator != null)
                viewsGenerator.TriggerStop();
        }

        private void MainForm_Load(object sender, EventArgs e) {

        }

        private void btnStartRating_Click(object sender, EventArgs e) {
            var accounts = LoadAccountsFromConfig();

            new Thread((ThreadStart)delegate {
                voter = new ShortnewsVoter(accounts, tbShortnewsRatingUrl.Text, driver);
                voter.Start(useTor: false);
            }).Start();
        }

        List<NetworkCredential> LoadAccountsFromConfig() {
            var accounts = new List<NetworkCredential>();

            var xmlDoc = new XmlDocument();
            xmlDoc.Load("Accounts.conf");

            foreach(XmlNode node in xmlDoc.DocumentElement.ChildNodes) {
                if(!node.OuterXml.StartsWith("<!--")) {
                    var account = new NetworkCredential(node.Attributes["userName"].InnerText, node.Attributes["password"].InnerText);
                    accounts.Add(account);
                }
            }

            return accounts;
        }
    }
}
