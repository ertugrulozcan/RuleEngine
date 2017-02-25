using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RuleEngine.Models
{
    public interface ICondition
    {
        string Property { get; }
        string Value { get; }
        ConditionValueType Type { get; }

        bool IsProper(object obj);
    }
}
