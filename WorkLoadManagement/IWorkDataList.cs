using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class WorkDataList
    {
        public List<WorkItem> itemList { get; private set; }

        public TimeSpan totaltime { get; set; }
        public Dictionary<string, TimeSpan> workcodetime { get; set; }

        public WorkDataList()
        {
            itemList = new List<WorkItem>();
        }

        
    }
}
