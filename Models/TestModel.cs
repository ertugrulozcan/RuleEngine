using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RuleEngine.Models
{
    public class TestModel : INotifyPropertyChanged
    {
        private bool testBool;
        private string testString;

        public bool TestBool
        {
            get
            {
                return testBool;
            }

            set
            {
                this.testBool = value;
                this.RaisePropertyChanged("TestBool");
            }
        }

        public string TestString
        {
            get
            {
                return testString;
            }

            set
            {
                this.testString = value;
                this.RaisePropertyChanged("TestString");
            }
        }

        public void TestMethod()
        {
            
        }

        #region RaisePropertyChanged

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
