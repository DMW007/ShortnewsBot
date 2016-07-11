using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ShortnewsBot.Config {
    public class AccountElement : ConfigurationElement {
        public AccountElement() { }

        [ConfigurationProperty("userName", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string UserName {
            get { return (string)this["userName"]; }
            set { this["userName"] = value; }
        }

        [ConfigurationProperty("password", DefaultValue = "", IsRequired = true)]
        public string SourcePath {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }
    }
}
