using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeManagementCore
{
    public interface IWorkItem
    {

    }
    public class WorkItem:IWorkItem
    {
        internal WorkItem(WorkItemBuilder builder)
        {
            //作成時はこちらを使う
            CreateTime = DateTime.Now;
            StartTime = builder.StartTime;
            EndTime = builder.EndTime;
            WorkCode = builder.workCode;
            Comment = builder.Comment;
            ID = Guid.NewGuid();
        }
        internal WorkItem()
        {
            //Output dataからの読み込み用
        }
        public Guid ID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string WorkCode { get; set; }
        public string Comment { get; set; }

        public TimeSpan GetWorkTime()
        {
            return EndTime - StartTime;
        }
    }

    public class NullWorkItem:IWorkItem
    {

    }

}
