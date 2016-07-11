using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShortnewsBot.ShortnewsAutomation {
    class ShortnewsTools {
        public static void KillLeaveLayerIfPresent(RemoteWebDriver driver) {
            var closePopups = driver.FindElementsByCssSelector("#close-popup a");
            if (closePopups.Count > 0) {
                driver.ExecuteScript("(elem=document.getElementById('exit-popup')).parentNode.removeChild(elem)");
            }

            var removeFramesJs = @"
                var element = document.getElementsByTagName('iframe');
                for (index = element.length - 1; index >= 0; index--) {
                    element[index].parentNode.removeChild(element[index]);
                }
            ";
            //driver.ExecuteScript(removeFramesJs);

            Thread.Sleep(1000);
        }
    }
}
