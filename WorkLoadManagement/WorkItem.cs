using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class WorkItem
    {
        internal WorkItem(WorkItemBuilder builder)
        {
            //作成時はこちらを使う
            CreateTime = DateTime.Now;
            StartTime = builder.StartTime;
            EndTime = builder.EndTime;
            workCode = builder.workCode;
            Comment = builder.Comment;
        }
        internal WorkItem()
        {
            //Output dataからの読み込み用
        }
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

}
