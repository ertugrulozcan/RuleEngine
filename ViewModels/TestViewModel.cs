using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Infrastructure;
using Test.RuleEngine.Manager;
using Test.RuleEngine.Models;

namespace Test.RuleEngine.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        #region Services

        private readonly IRuleManager ruleManager;

        #endregion

        #region Fields

        private bool case1 = true;
        private bool case2 = true;
        private bool case3 = false;
        private int number = 13;
        private double floating = 123.456;
        private TestModel testObject;

        #endregion

        #region Properties

        public bool Case1
        {
            get
            {
                return case1;
            }

            set
            {
                this.case1 = value;
            }
        }

        public bool Case2
        {
            get
            {
                return case2;
            }

            set
            {
                this.case2 = value;
            }
        }

        public bool Case3
        {
            get
            {
                return case3;
            }

            set
            {
                this.case3 = value;
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                this.number = value;
            }
        }

        public double Floating
        {
            get
            {
                return floating;
            }

            set
            {
                this.floating = value;
            }
        }

        public TestModel TestObject
        {
            get
            {
                return testObject;
            }

            set
            {
                this.testObject = value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public TestViewModel(IRuleManager ruleManager) : base(Guid.NewGuid().ToString())
        {
            this.ruleManager = ruleManager;

            this.TestObject = new TestModel();
            var ruleSet = this.ruleManager.RuleSetDictionary["RuleSet1"];
            foreach (var rule in ruleSet.RuleList)
            {
                rule.ApplyRule(this);
            }
        }

        #endregion

        #region Methods

        public void RuleTest()
        {
            System.Windows.Forms.MessageBox.Show("Success! :)", "RuleManager");
        }

        #endregion
    }
}
