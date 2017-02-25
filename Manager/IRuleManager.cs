using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RuleEngine.Models;

namespace Test.RuleEngine.Manager
{
    public interface IRuleManager
    {
        Dictionary<string, RuleSet> RuleSetDictionary { get; }
        bool ApplyRule(object obj, Rule rule);
    }
}
