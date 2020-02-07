using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkTimeManagementCore.Interface;

namespace WorkTimeManagementCore
{
    public class CollectionController
    {
       
        public TotalCollection TotalCollection { get; set; }
        public Dictionary<DateTime,MonthlyCollection> MonthlyCollections { get; set; }
        public Dictionary<DateTime, DaylyCollection> DaylyCollections { get; set; }
        private MonthlyCollectionController monthlyCollectionController;


        public CollectionController()
        {
            TotalCollection = new TotalCollection();
            MonthlyCollections = new Dictionary<DateTime, MonthlyCollection>();
            DaylyCollections = new Dictionary<DateTime, DaylyCollection>();
            monthlyCollectionController = new MonthlyCollectionController(MonthlyCollections);
        }

        public void LoadData(List<IWorkItem> itemlist)
        {
            TotalCollection.AddItemList(itemlist);
            monthlyCollectionController.AddItemList(itemlist);
        }

        public void AddItem(IWorkItem item)
        {
            TotalCollection.AddItem(item);
            monthlyCollectionController.AddItem(item);
        }

        public IWorkItem GetItem(Guid id)
        {
            return TotalCollection.GetItem(id);
        }
        public List<IWorkItem> ReadItemList()
        {
            return TotalCollection.ReadItemList();
        }
        public void UpdateItem(Guid id,IWorkItem item)
        {
            TotalCollection.UpdateItem(id, item);
            var workitem = TotalCollection.GetItem(id);
            monthlyCollectionController.UpdateItem(workitem.StartTime, id, item);


        }
        public void DeleteItem(Guid id)
        {
            TotalCollection.DeleteItem(id);
            var workitem = TotalCollection.GetItem(id);
            monthlyCollectionController.DeleteItem(workitem.StartTime,id);
        }
        public void ClearItemList()
        {
            TotalCollection.ClearItemList();
        }
        
    }
    public class MonthlyCollectionController
    {
        private Dictionary<DateTime,MonthlyCollection> mycollection;

        public MonthlyCollectionController(Dictionary<DateTime,MonthlyCollection> collection)
        {
            mycollection = collection;
        }


        public void AddItem(IWorkItem item)
        {
            DateTime date = item.StartTime.Date;
            if(isExist(date))
            {
                mycollection[date].AddItem(item);
            }
            else
            {
                CreateCollection(date);
                mycollection[date].AddItem(item);
            }
        }

        public void AddItemList(List<IWorkItem> itemlist)
        {
            foreach(var item in itemlist)
            {
                AddItem(item);
            }
        }

        public List<IWorkItem> ReadItemList(DateTime date)
        {
            return mycollection[date].MonthlyItemList;
        }

        public void UpdateItem(DateTime date,Guid id,IWorkItem item)
        {
            DateTime monthdate = date.Date;
            mycollection[monthdate].UpdateItem(id, item);

        }
        public void DeleteItem(DateTime date,Guid id)
        {

        }

        private void CreateCollection(DateTime date)
        {
            mycollection.Add(date, new MonthlyCollection(date));
        }

        
        private bool isExist(DateTime date)
        {
            if(mycollection.ContainsKey(date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class DaylyCollectionController
    {
        private Dictionary<DateTime, DaylyCollection> mycollection;

        public DaylyCollectionController(Dictionary<DateTime, DaylyCollection> collection)
        {
            mycollection = collection;
        }


        public void AddItem(IWorkItem item)
        {
            DateTime date = item.StartTime.Date;
            if (isExist(date))
            {
                mycollection[date].AddItem(item);
            }
            else
            {
                CreateCollection(date);
                mycollection[date].AddItem(item);
            }
        }

        public void AddItemList(List<IWorkItem> itemlist)
        {
            foreach (var item in itemlist)
            {
                AddItem(item);
            }
        }

        public List<IWorkItem> ReadItemList(DateTime date)
        {
            return mycollection[date].DaylyWorkItemList;
        }

        public void UpdateItem(DateTime date, Guid id, IWorkItem item)
        {
            DateTime monthdate = date.Date;
            mycollection[monthdate].UpdateItem(id, item);

        }
        public void DeleteItem(DateTime date, Guid id)
        {

        }

        private void CreateCollection(DateTime date)
        {
            mycollection.Add(date, new DaylyCollection(date));
        }


        private bool isExist(DateTime date)
        {
            if (mycollection.ContainsKey(date))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
