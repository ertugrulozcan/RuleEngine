using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Test.RuleEngine.Models;
using Test.RuleEngine.Helpers;

namespace Test.RuleEngine.Manager
{
    public class RuleManager : IRuleManager
    {
        #region Fields

        private Dictionary<string, RuleSet> ruleSetDictionary;

        #endregion

        #region Properties

        public Dictionary<string, RuleSet> RuleSetDictionary
        {
            get
            {
                return this.ruleSetDictionary;
            }
            private set
            {
                this.ruleSetDictionary = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleManager()
        {
            this.ReadRuleSet();
        }

        #endregion

        #region Methods

        private void ReadRuleSet()
        {
            this.RuleSetDictionary = new Dictionary<string, RuleSet>();

            string resourcesPath = ResourcesPath;
            if (Directory.Exists(resourcesPath))
            {
                var files = Directory.GetFiles(resourcesPath);
                foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        try
                        {
                            Models.RuleSet ruleSet = Serialization.RuleSerializer.Serialize(file);
                            this.RuleSetDictionary.Add(ruleSet.Name, ruleSet);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(string.Format("RuleSet serialization failed from resource [{0}]\n\t{1}", file, ex.Message));
                        }
                    }
                }
            }
        }

        private static string ResourcesPath
        {
            get
            {
                string path, applicationDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                if (applicationDirectory.Contains(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)))
                    path = Path.Combine(applicationDirectory, "Resources");
                else
                    path = Path.Combine(Directory.GetParent(applicationDirectory).Parent.FullName, "Resources");

                return path;
            }
        }

        public bool ApplyRule(object obj, Rule rule)
        {
            if (rule != null)
            {
                return rule.ApplyRule(obj);
            }
            else
                return false;
        }

        #endregion
    }
}
