using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeManagementCore
{
    public class WorkItemBuilder
    {
        public Guid ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string WorkCode { get; set; }
        public string Comment { get; set; }

        public WorkItem Build(out List<string> errormsg)
        {
            errormsg = new List<string>();
            if(EndTime<StartTime)
            {
                errormsg.Add("Time Setting Error");
                //throw new Exception("End Time Setting Error");
            }
            if(WorkCode==null)
            {
                errormsg.Add("No WorkCode Error");
                //throw new ArgumentNullException("WorkCode Null");
            }
            if(Comment==null)
            {
                Comment = string.Empty;
            }

            return new WorkItem(this);
        }
    }
}
