using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class WorkItem
    {
        public WorkItem()
        {
            CreateTime = DateTime.Now;
        }
        public string Title {get;set;}
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string workCode { get; set; }
        public string Comment { get; set; }

        public TimeSpan GetWorkTime()
        {
            return EndTime - StartTime;
        }
    }

    public class WorkCode
    {
        public WorkCode()
        {
        }

    }
}
