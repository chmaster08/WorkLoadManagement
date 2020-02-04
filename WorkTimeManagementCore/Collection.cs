using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkTimeManagementCore.Interface;

namespace WorkTimeManagementCore
{

    
    public class DaylyCollection : ICollection
    {
        public List<IWorkItem> DaylyWorkItemList { get; private set; }
        public DateTime Date { get; set; }


        public TimeSpan Totaltime { get; private set; }

        public Collections CollectionType
        {
            get
            {
                return Collections.Dayly;
            }

        }

        public DaylyCollection(DateTime date)
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
        public DateTime Date { get; set; }

        public Collections CollectionType
        {
            get
            {
                return Collections.Monthly;
            }

        }
        public MonthlyCollection(DateTime date)
        {
            MonthlyItemList = new List<IWorkItem>();
        }

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
        public List<IWorkItem> TotalWorkItem { get; private set; }
        public DateTime Date { get; set; }

        public Collections CollectionType
        {
            get
            {
                return Collections.Total;
            }

        }

        public void AddItem(IWorkItem item)
        {
            if(item is WorkItem)
            {
                TotalWorkItem.Add(item);
            }
        }

        public void AddItemList(List<IWorkItem> workItemList)
        {
            foreach(var item in workItemList)
            {
                if(item is WorkItem)
                {
                    TotalWorkItem.Add(item);
                }
            }
        }

        public void ClearItemList()
        {
            TotalWorkItem.Clear();
        }

        public void DeleteItem(Guid id)
        {
            TotalWorkItem.RemoveAll(item => item.ID == id);
        }

        public IWorkItem GetItem(Guid id)
        {
            var item = TotalWorkItem.Find(n => n.ID == id);
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
            return TotalWorkItem;
        }

        public void UpdateItem(Guid id, IWorkItem item)
        {
            if (item is WorkItem)
            {
                TotalWorkItem.Where(n => n.ID == id)
                    .Select(x => x = item);
            }
            else
            {
                throw new Exception("No item");
            }

        }
    }
}
