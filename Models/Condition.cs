using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RuleEngine.Models
{
    [Serializable()]
    public class Condition : ICondition
    {
        #region Fields

        private string property;
        private string value;
        private ConditionValueType type = ConditionValueType.String;
        private ComparisonMethod method = ComparisonMethod.Equal;

        #endregion

        #region Properties

        [System.Xml.Serialization.XmlAttribute]
        public string Property
        {
            get
            {
                return property;
            }

            set
            {
                this.property = value;
            }
        }

        [System.Xml.Serialization.XmlAttribute]
        [System.Xml.Serialization.XmlText]
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

        [System.Xml.Serialization.XmlAttribute]
        public ConditionValueType Type
        {
            get
            {
                return type;
            }

            set
            {
                this.type = value;
            }
        }

        [System.Xml.Serialization.XmlAttribute]
        public ComparisonMethod Method
        {
            get
            {
                return method;
            }

            set
            {
                this.method = value;
            }
        }

        #endregion

        #region Constructor



        #endregion

        #region Methods

        public bool IsProper(object obj)
        {
            switch (this.Method)
            {
                case ComparisonMethod.Greater:
                {
                    if (this.Type == ConditionValueType.Numeric)
                    {
                        double number;
                        bool isParsed = Double.TryParse(this.Value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
                        if (isParsed)
                            return number < Double.Parse(obj.ToString());
                        else
                            throw new Exception("DoubleParsingException");
                    }
                    else
                        throw new Exception("Condition type is not numerical. GreaterThan operator cannot be applied to operand of this type.");
                }

                case ComparisonMethod.GreaterOrEqual:
                {
                    if (this.Type == ConditionValueType.Numeric)
                    {
                        double number;
                        bool isParsed = Double.TryParse(this.Value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
                        if (isParsed)
                            return number <= Double.Parse(obj.ToString());
                        else
                            throw new Exception("DoubleParsingException");
                    }
                    else
                        throw new Exception("Condition type is not numerical. GreaterOrEqual operator cannot be applied to operand of this type.");
                }

                case ComparisonMethod.Less:
                {
                    if (this.Type == ConditionValueType.Numeric)
                    {
                        double number;
                        bool isParsed = Double.TryParse(this.Value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
                        if (isParsed)
                            return number > Double.Parse(obj.ToString());
                        else
                            throw new Exception("DoubleParsingException");
                    }
                    else
                        throw new Exception("Condition type is not numerical. LessThan operator cannot be applied to operand of this type.");
                }

                case ComparisonMethod.LessOrEqual:
                {
                    if (this.Type == ConditionValueType.Numeric)
                    {
                        double number;
                        bool isParsed = Double.TryParse(this.Value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
                        if (isParsed)
                            return number >= Double.Parse(obj.ToString());
                        else
                            throw new Exception("DoubleParsingException");
                    }
                    else
                        throw new Exception("Condition type is not numerical. LessOrEqual operator cannot be applied to operand of this type.");
                }

                case ComparisonMethod.And:
                {
                    if (this.Type == ConditionValueType.Bool)
                    {
                        bool boolean;
                        bool isParsed = Boolean.TryParse(this.Value, out boolean);
                        if (isParsed)
                            return boolean && (bool)obj;
                        else
                            throw new Exception("BooleanParsingException");
                    }
                    else
                        throw new Exception("Condition type is not boolean. And operator cannot be applied to operand of this type.");
                }

                case ComparisonMethod.Or:
                {
                    if (this.Type == ConditionValueType.Bool)
                    {
                        bool boolean;
                        bool isParsed = Boolean.TryParse(this.Value, out boolean);
                        if (isParsed)
                            return boolean || (bool)obj;
                        else
                            throw new Exception("BooleanParsingException");
                    }
                    else
                        throw new Exception("Condition type is not boolean. Or operator cannot be applied to operand of this type.");
                }

                case ComparisonMethod.NotEqual:
                return !this.Equals(obj);

                case ComparisonMethod.Equal:
                default:
                return this.Equals(obj);
            }
        }

        public override bool Equals(object obj)
        {
            if (this.Type == ConditionValueType.Bool)
            {
                if (obj is bool)
                {
                    bool boolean;
                    bool isParsed = Boolean.TryParse(this.Value, out boolean);
                    if (isParsed)
                        return boolean == (bool)obj;
                }
                else
                    return false;
            }

            if (this.Type == ConditionValueType.Numeric)
            {
                if (Helpers.ReflectionHelper.IsNumericType(obj))
                {
                    double number;
                    bool isParsed = Double.TryParse(this.Value, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
                    if (isParsed)
                        return number == Double.Parse(obj.ToString());
                }
                else
                    return false;
            }

            return this.Value == obj.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            if (this.Type == ConditionValueType.Bool)
            {
                bool boolean;
                bool isParsed = Boolean.TryParse(this.Value, out boolean);
                if (isParsed)
                    return boolean.ToString();
            }

            if (this.Type == ConditionValueType.Numeric)
            {
                double number;
                bool isParsed = Double.TryParse(this.Value, out number);
                if (isParsed)
                    return number.ToString();
            }

            return this.Value;
        }
        
        #endregion
    }

    #region Enums

    public enum ConditionValueType
    {
        String,
        Bool,
        Numeric,
    }

    public enum ComparisonMethod
    {
        Equal,
        NotEqual,
        Greater,
        GreaterOrEqual,
        Less,
        LessOrEqual,
        And,
        Or,
    }

    #endregion
}
