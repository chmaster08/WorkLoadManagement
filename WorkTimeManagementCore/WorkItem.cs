using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTimeManagementCore
{
    public interface IWorkItem
    {
        Guid ID { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        DateTime CreateTime { get; set; }
        string WorkCode { get; set; }
        string Comment { get; set; }
        TimeSpan WorkTime { get; }

    }
    public class WorkItem:IWorkItem
    {
        internal WorkItem(WorkItemBuilder builder)
        {
            //作成時はこちらを使う
            CreateTime = DateTime.Now;
            StartTime = builder.StartTime;
            EndTime = builder.EndTime;
            WorkCode = builder.WorkCode;
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
        public TimeSpan WorkTime
        {
            get {return EndTime - StartTime; }
        }

        public TimeSpan GetWorkTime()
        {
            return EndTime - StartTime;
        }
    }

    public class NullWorkItem : IWorkItem
    {
        public Guid ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime StartTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime EndTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime CreateTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string WorkCode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Comment { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TimeSpan WorkTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    }

}
