using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortnewsBot.Config {
    [ConfigurationCollection(typeof(AccountElement))]
    public class AccountElementCollection : ConfigurationElementCollection {
        public AccountElement this[int index] {
            get { return (AccountElement)BaseGet(index); }
            set {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);

                BaseAdd(index, value);
            }
        }
        protected override ConfigurationElement CreateNewElement() {
            
            return new AccountElement();
        }

        protected override object GetElementKey(ConfigurationElement element) {
            return ((AccountElement)element).UserName;
        }
    }

    public class AccountSection : ConfigurationSection {
        [ConfigurationProperty("shortnewsAccounts")]
        public AccountElementCollection ShortnewsAccounts {
            get { return (AccountElementCollection)this["shortnewsAccounts"]; }
        }
    }

    public class AccountsConfig {
        public static AccountSection config = ConfigurationManager.GetSection("shortnewsAccounts") as AccountSection;

        public static AccountElementCollection GetAccounts() {
            return config.ShortnewsAccounts;
        }
    }
}
