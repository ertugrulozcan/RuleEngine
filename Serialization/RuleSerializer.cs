using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Test.RuleEngine.Models;

namespace Test.RuleEngine.Serialization
{
    public static class RuleSerializer
    {
        public static RuleSet Serialize(string documentPath)
        {
            RuleSet ruleSet = null;
            XmlSerializer serializer = new XmlSerializer(typeof(RuleSet));
            using (StreamReader reader = new StreamReader(documentPath))
            {
                ruleSet = (RuleSet)serializer.Deserialize(reader);
                reader.Close();
            }

            return ruleSet;
        }
    }
}
