using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkTimeManagementCore.Interface;

namespace WorkTimeManagementCore
{

    
    public class DaylyCollection : IPartialCollection
    {
        public List<IWorkItem> WorkItemList { get; set; }
        public string Date { get; set; }


        public TimeSpan TotalTime { get; private set; }

        public Collections CollectionType
        {
            get
            {
                return Collections.Dayly;
            }

        }

        public DaylyCollection(DateTime date)
        {
            WorkItemList = new List<IWorkItem>();
            Date = date.ToString("yyyy/MM/dd");
        }

        public void AddItem(IWorkItem item)
        {
            if( item is WorkItem)
            {
                WorkItemList.Add(item);
                Calc(item);

            }
        }

        public void AddItemList(List<IWorkItem> workItemList)
        {
            foreach(var item in workItemList)
            {
                if(item is WorkItem)
                {
                    WorkItemList.Add(item);
                }
            }
        }

        public IWorkItem GetItem(Guid id)
        {
            var item = WorkItemList.Find(n => n.ID == id);
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
            return WorkItemList;
        }

        public void UpdateItem(Guid id, IWorkItem item)
        {
            if (item is WorkItem)
            {
                DeleteItem(id);
                AddItem(item);

            }
            else
            {
                throw new Exception("No item");
            }

        }

        public void DeleteItem(Guid id)
        {
            minuscalc(id);
            WorkItemList.RemoveAll(item => item.ID == id);
        }

        public void ClearItemList()
        {
            WorkItemList.Clear();
        }
        public void Calc(IWorkItem item)
        {
            TotalTime += (item.EndTime - item.StartTime);
            
        }
        private void minuscalc(Guid id)
        {
            var previtem = GetItem(id);
            TotalTime -= previtem.WorkTime;
        }
    }

    public class MonthlyCollection : IPartialCollection
    {
        public List<IWorkItem> WorkItemList { get; set; }
        public TimeSpan TotalTime { get; private set; }
        public Dictionary<string,TimeSpan> MonthlyWorkCodeTime { get; private set; }
        public string  Date{ get; set; }

        public Collections CollectionType
        {
            get
            {
                return Collections.Monthly;
            }

        }
        public MonthlyCollection(DateTime date)
        {
            WorkItemList = new List<IWorkItem>();
        }

        public void AddItem(IWorkItem item)
        {
            if(item is WorkItem)
            {
                WorkItemList.Add(item);
                Calc(item);
            }
        }

        public void AddItemList(List<IWorkItem> workItemList)
        {
            foreach(var item in workItemList)
            {
                if(item is WorkItem)
                {
                    WorkItemList.Add(item);
                }
                else
                {
                    throw new Exception("Include Null Object");
                }
            }
        }

        public void ClearItemList()
        {
            WorkItemList.Clear();
        }

        public void DeleteItem(Guid id)
        {
            minuscalc(id);
            WorkItemList.RemoveAll(item => item.ID == id);
        }

        public IWorkItem GetItem(Guid id)
        {
            var item = WorkItemList.Find(n => n.ID == id);
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
            return WorkItemList;
        }

        public void UpdateItem(Guid id, IWorkItem item)
        {
            if (item is WorkItem)
            {
                DeleteItem(id);
                AddItem(item);

            }
            else
            {
                throw new Exception("No item");
            }

        }
        public void Calc(IWorkItem item)
        {
            TotalTime += (item.EndTime - item.StartTime);
            string workcode = item.WorkCode;
            if (!MonthlyWorkCodeTime.ContainsKey(workcode))
            {
                MonthlyWorkCodeTime[workcode] = item.WorkTime;
            }
            else
            {
                MonthlyWorkCodeTime[workcode] += item.WorkTime;
            }
        }
        private void minuscalc(Guid id)
        {
            var previtem = GetItem(id);
            MonthlyWorkCodeTime[previtem.WorkCode] -= previtem.WorkTime;
            TotalTime -= previtem.WorkTime;
        }
        
    }

    public class TotalCollection : ICollection
    {
        public List<IWorkItem> WorkItemList { get; set; }
        public TimeSpan TotalTime { get; private set; }

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
                WorkItemList.Add(item);
                Calc(item);
            }
        }

        public void AddItemList(List<IWorkItem> workItemList)
        {
            foreach(var item in workItemList)
            {
                if(item is WorkItem)
                {
                    WorkItemList.Add(item);
                }
            }
        }

        public void ClearItemList()
        {
            WorkItemList.Clear();
            TotalTime = new TimeSpan(0, 0, 0);
        }

        public void DeleteItem(Guid id)
        {
            minusCalc(id);
            WorkItemList.Remove(GetItem(id));
        }

        public IWorkItem GetItem(Guid id)
        {
            var item = WorkItemList.Find(n => n.ID == id);
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
            return WorkItemList;
        }

        public void UpdateItem(Guid id, IWorkItem item)
        {
            if (item is WorkItem)
            {
                DeleteItem(id);
                AddItem(item);
            }
            else
            {
                throw new Exception("No item");
            }

        }
        private void Calc(IWorkItem item)
        {
            
            TotalTime += item.WorkTime;
            
        }
        private void minusCalc(Guid id)
        {
            var item = GetItem(id);
            TotalTime -= item.WorkTime;
        }
    }
}
