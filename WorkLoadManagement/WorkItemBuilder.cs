using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class WorkItemBuilder
    {
        public Guid ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string workCode { get; set; }
        public string Comment { get; set; }

        public WorkItem Build()
        {
            if(EndTime<StartTime)
            {
                throw new Exception("End Time Setting Error");
            }
            if(workCode==null)
            {
                throw new ArgumentNullException("WorkCode Null");
            }

            return new WorkItem(this);
        }
    }
}
