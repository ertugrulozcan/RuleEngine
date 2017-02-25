using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RuleEngine.Helpers;

namespace Test.RuleEngine.Models
{
    [Serializable()]
    public class Setter : IAction
    {
        #region Fields

        private string propertyName;
        private string value;

        #endregion

        #region Properties

        [System.Xml.Serialization.XmlAttribute("Property")]
        public string PropertyName
        {
            get
            {
                return propertyName;
            }

            set
            {
                this.propertyName = value;
            }
        }

        [System.Xml.Serialization.XmlAttribute("Value")]
        public string Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }

        #endregion

        #region Methods

        public void Execute(object obj)
        {
            obj.SetPropValue(this.PropertyName, this.Value);
        }

        #endregion
    }
}
