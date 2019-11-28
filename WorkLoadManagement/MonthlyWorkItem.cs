using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class MonthlyWorkItem 
    {
        private List<WorkItem> itemList;

        private TimeSpan totaltime;
        private List<string> workcodelist;
        private Dictionary<string, TimeSpan> workcodetime;

        public MonthlyWorkItem(DateTime dateTime)
        {
            //月を指定できるように  
        }

    }
}
