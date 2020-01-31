using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkTimeManagementCore
{
    public class DaylyCollection : ICollection
    {
        public List<IWorkItem> DaylyWorkItemList { get; private set; }
        public TimeSpan Totaltime { get; private set; }

        public DaylyCollection()
        {
            DaylyWorkItemList = new List<IWorkItem>();
        }

        public void AddItem(IWorkItem item)
        {
            if( item is WorkItem)
            {
                DaylyWorkItemList.Add(item);
            }
        }

        public void AddItemList(List<IWorkItem> workItemList)
        {
            foreach(var item in workItemList)
            {
                if(item is WorkItem)
                {
                    DaylyWorkItemList.Add(item);
                }
            }
        }

        public IWorkItem GetItem(Guid id)
        {
            var item = DaylyWorkItemList.Find(n => n.ID == id);
            if(item!=null)
            {
                return item;
            }
            else
            {
                return new NullWorkItem();
            }
        }

        public List<IWorkItem> ReadItemList()
        {
            return DaylyWorkItemList;
        }

        public void UpdateItem(Guid id,IWorkItem item)
        {
            if(item is WorkItem)
            {
                DaylyWorkItemList.Where(n => n.ID == id)
                    .Select(x => x = item);
            }
            else
            {
                throw new Exception("No item");
            }
        }

        public void DeleteItem(Guid id)
        {
            DaylyWorkItemList.RemoveAll(item => item.ID == id);
        }

        public void ClearItemList()
        {
            DaylyWorkItemList.Clear();
        }
    }

    public class MonthlyCollection : ICollection
    {
        public List<IWorkItem> MonthlyItemList { get; private set; }
        public TimeSpan TotalTime { get; private set; }
        public Dictionary<string,TimeSpan> MonthlyWorkCodeTime { get; private set; }
        public void AddItem(IWorkItem item)
        {
            if(item is WorkItem)
            {
                MonthlyItemList.Add(item);
            }
        }

        public void AddItemList(List<IWorkItem> workItemList)
        {
            foreach(var item in workItemList)
            {
                if(item is WorkItem)
                {
                    MonthlyItemList.Add(item);
                }
                else
                {
                    throw new Exception("Include Null Object");
                }
            }
        }

        public void ClearItemList()
        {
            MonthlyItemList.Clear();
        }

        public void DeleteItem(Guid id)
        {
            MonthlyItemList.RemoveAll(item => item.ID == id);
        }

        public IWorkItem GetItem(Guid id)
        {
            var item = MonthlyItemList.Find(n => n.ID == id);
            if (item != null)
            {
                return item;
            }
            else
            {
                return new NullWorkItem();
            }

        }

        public List<IWorkItem> ReadItemList()
        {
            return MonthlyItemList;
        }

        public void UpdateItem(Guid id, IWorkItem item)
        {
            if (item is WorkItem)
            {
                MonthlyItemList.Where(n => n.ID == id)
                    .Select(x => x = item);
            }
            else
            {
                throw new Exception("No item");
            }

        }
    }

    public class TotalCollection : ICollection
    {
        public void AddItem(IWorkItem item)
        {
            throw new NotImplementedException();
        }

        public void AddItemList(List<IWorkItem> workItemList)
        {
            throw new NotImplementedException();
        }

        public void ClearItemList()
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IWorkItem GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<IWorkItem> ReadItemList()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(Guid id, IWorkItem item)
        {
            throw new NotImplementedException();
        }
    }
}
