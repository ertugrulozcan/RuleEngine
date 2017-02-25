using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RuleEngine.Models
{
    public interface IAction
    {
        void Execute(object obj);
    }
}
