using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RuleEngine.Helpers;

namespace Test.RuleEngine.Models
{
    [Serializable()]
    public class Action : IAction
    {
        #region Fields

        private string methodName;
        private string[] parameters;

        #endregion

        #region Properties

        [System.Xml.Serialization.XmlAttribute("Method")]
        public string MethodName
        {
            get
            {
                return methodName;
            }

            set
            {
                this.methodName = value;
            }
        }

        [System.Xml.Serialization.XmlArray("Action.Parameters")]
        [System.Xml.Serialization.XmlArrayItem("Parameter", typeof(string), IsNullable = true)]
        public string[] Parameters
        {
            get
            {
                return parameters;
            }

            set
            {
                this.parameters = value;
            }
        }

        #endregion

        #region Methods

        public void Execute(object obj)
        {
            obj.ExecuteMethod(this.MethodName, this.Parameters);
        }

        #endregion
    }
}
