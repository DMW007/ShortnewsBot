using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortnewsBot {
    class FirefoxDriverCreator {
        public static FirefoxDriver CreateFirefoxDriverWithAdblock(FirefoxProfile firefoxProfile = null, string adblockXpiPath = "adblock_plus-2.7.3-sm+tb+fx+an.xpi", string adblockVersion = "2.7.3") {
            if (firefoxProfile == null)
                firefoxProfile = new FirefoxProfile("SeleniumFirefoxProfileDirectory");

            firefoxProfile.AddExtension(adblockXpiPath);
            firefoxProfile.SetPreference("extensions.adblockplus.currentVersion", adblockVersion);

            return new FirefoxDriver(firefoxProfile);
        }

        public static FirefoxProfile SetSocksProxy(string host, int port, int socksVersion = 5, FirefoxProfile firefoxProfile = null) {
            if (firefoxProfile == null)
                firefoxProfile = new FirefoxProfile();

            firefoxProfile.SetPreference("network.proxy.socks", host);
            firefoxProfile.SetPreference("network.proxy.socks_port", port);
            firefoxProfile.SetPreference("network.proxy.socks_version", socksVersion);
            firefoxProfile.SetPreference("network.proxy.type", 1);
            firefoxProfile.SetPreference("network.proxy.socks_remote_dns", true);

            return firefoxProfile;
        }
    }
}
