using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShortnewsBot.ShortnewsAutomation {
    class ShortnewsRegister {
        RemoteWebDriver driver;
        string baseUrl = "http://shortnews.de";

        public enum RegisterResult {
            Success,
            MailProviderNotAccepted,
            MailAlreadyUsed,
            UserNameAlreadyTaken
        }

        public ShortnewsRegister(RemoteWebDriver driver) {
            this.driver = driver;
        }

        public RegisterResult RegisterUser(string mail, string userName) {
            driver.Navigate().GoToUrl(baseUrl);
            // Öffnet das Registrierungsformular
            driver.ExecuteScript("xaja_start_registration()");
            // Nach dem Aufrufen legt sich häufig ein Layer über den Bildschirm zur Bestätigung, ob man die Seite verlassen möchte - Dieser muss entfernt werden, falls vorhanden
            ShortnewsTools.KillLeaveLayerIfPresent(driver);

            var userNameField = driver.FindElementById("xaja_reg_username");
            userNameField.SendKeys(userName);

            var mailField = driver.FindElementById("xaja_reg_email");
            mailField.SendKeys(mail);

            var tosCheckbox = driver.FindElementById("xaja_reg_agb");
            tosCheckbox.Click();

            var newsletterCheckbox = driver.FindElementById("xaja_reg_nl");
            newsletterCheckbox.Click();

            var doRegisterJs = ((IJavaScriptExecutor)driver).ExecuteScript("xaja_register_onclick()");

            var boxHeadline = driver.FindElementsById("xaja_form_headline");
            if(boxHeadline.Count > 0) {
                if (boxHeadline.FirstOrDefault().Text.Contains("LOGIN"))
                    return RegisterResult.Success;
            }

            var errorMsgs = driver.FindElementsById("xaja_message");
            if(errorMsgs.Count > 0) {
                var errorMsg = errorMsgs.FirstOrDefault();
                if (errorMsg.Text.Contains("EMail-Adresse leider bereits vorhanden"))
                    return RegisterResult.MailAlreadyUsed;
            }

            return RegisterResult.UserNameAlreadyTaken;
        }
    }
}
