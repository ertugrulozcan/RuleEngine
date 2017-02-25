using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RuleEngine.Helpers;

namespace Test.RuleEngine.Models
{
    [Serializable()]
    public class Rule
    {
        #region Fields

        private string name;
        private Condition[] conditionList;
        private Action action;
        private Setter[] setterList;
        private Action callback;

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

        [System.Xml.Serialization.XmlArray("Rule.Conditions")]
        [System.Xml.Serialization.XmlArrayItem("Condition", typeof(Condition), IsNullable = true)]
        public Condition[] ConditionList
        {
            get
            {
                return conditionList;
            }

            set
            {
                this.conditionList = value;
            }
        }

        [System.Xml.Serialization.XmlElement("Rule.Action", typeof(Action), IsNullable = true)]
        public Action Action
        {
            get
            {
                return action;
            }

            set
            {
                this.action = value;
            }
        }

        [System.Xml.Serialization.XmlArray("Rule.Setters")]
        [System.Xml.Serialization.XmlArrayItem("Setter", typeof(Setter), IsNullable = true)]
        public Setter[] SetterList
        {
            get
            {
                return setterList;
            }

            set
            {
                this.setterList = value;
            }
        }

        [System.Xml.Serialization.XmlElement("Rule.Callback", typeof(Action), IsNullable = true)]
        public Action Callback
        {
            get
            {
                return callback;
            }

            set
            {
                this.callback = value;
            }
        }

        #endregion

        #region Constructor
        


        #endregion

        #region Methods

        public bool ApplyRule(object obj)
        {
            bool isConditionsProvided = true;
            foreach (var condition in this.ConditionList)
            {
                if (obj.HasProperty(condition.Property))
                {
                    var propValue = obj.GetPropValue(condition.Property);
                    isConditionsProvided &= condition.IsProper(propValue);
                }
            }

            // Is all conditions provided?
            if (isConditionsProvided)
            {
                // Fire Action!
                if (this.Action != null)
                    this.Action.Execute(obj);

                foreach (var setter in this.SetterList)
                {
                    setter.Execute(obj);
                }

                if (this.Callback != null)
                    this.Callback.Execute(obj);
            }

            return isConditionsProvided;
        }

        #endregion
    }
}
