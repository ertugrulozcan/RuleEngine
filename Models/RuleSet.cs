using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RuleEngine.Models
{
    [Serializable()]
    [System.Xml.Serialization.XmlRoot("RuleSet")]
    public class RuleSet
    {
        #region Fields

        private string name;
        private Rule[] ruleList;

        #endregion

        #region Properties

        [System.Xml.Serialization.XmlAttribute]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                this.name = value;
            }
        }

        [System.Xml.Serialization.XmlArray("RuleSet.Rules")]
        [System.Xml.Serialization.XmlArrayItem("Rule", typeof(Rule))]
        public Rule[] RuleList
        {
            get
            {
                return ruleList;
            }

            set
            {
                this.ruleList = value;
            }
        }

        #endregion
    }
}
