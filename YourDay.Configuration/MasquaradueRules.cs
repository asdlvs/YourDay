using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace YourDay.Configuration
{
    public class MasquaradueRulesConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("rules")]
        [ConfigurationCollection(typeof(Rules), AddItemName = "add")]
        public Rules Rules
        {
            get { return (Rules)this["rules"]; }
            set { this["rules"] = value; }
        }
    }

    public class Rules : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Rule();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Rule)element).Link;
        }

        public Rule GetByKey(string key)
        {
            foreach (Rule rule in this)
            {
                if (rule.Key == key)
                {
                    return rule;
                }
            }
            return null;
        }


    }

    public class Rule : ConfigurationElement
    {
        [ConfigurationProperty("key", IsKey = true, IsRequired = true)]
        public string Key
        {
            get { return (string)this["key"]; }
        }

        [ConfigurationProperty("request", IsRequired = true)]
        public string Request
        {
            get { return (string)this["request"]; }
            set { this["request"] = value; }
        }

        [ConfigurationProperty("regex", IsRequired = true)]
        public string Regex
        {
            get { return (string)this["regex"]; }
            set { this["regex"] = value; }
        }

        [ConfigurationProperty("link", IsRequired = true)]
        public string Link
        {
            get { return (string)this["link"]; }
            set { this["link"] = value; }
        }
        [ConfigurationProperty("enableUnauthAccess", IsRequired = true)]
        public bool EnableUnauthorizedAccess
        {
            get { return (bool)this["enableUnauthAccess"]; }
            set { this["enableUnauthAccess"] = value; }
        }
        [ConfigurationProperty("isHandler", IsRequired = false)]
        public bool IsHandler
        {
            get { return (bool)this["isHandler"]; }
            set { this["isHandler"] = value; }
        }
        [ConfigurationProperty("actualRoles", IsRequired = false)]
        private string actualRoles
        {
            get { return (string)this["actualRoles"]; }
            set { this["actualRoles"] = value; }
        }

        public string[] ActualRoles
        {
            get { return this.actualRoles.Split(','); }
        }
    }
}
