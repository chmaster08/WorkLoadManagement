using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WorkLoadManagement
{
    public class TestList
    {
        public ObservableCollection<Test> Data { get; }

        public TestList()
        {
            Data = new ObservableCollection<Test>
            {
                new Test{a=1,s="takuto",d=178.5},
                new Test{a=2,s="chiharu",d=160.5},
                new Test{a=3,s="erina",d=150.0}

            };
        }
    }
}
