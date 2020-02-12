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
        public Dictionary<string, IPartialCollection> CollectionList { get; set; }


        public CollectionController()
        {
            TotalCollection = new TotalCollection();
            CollectionList = new Dictionary<string, IPartialCollection>();
        }


        public void AddItem(IWorkItem item)
        {
            TotalCollection.AddItem(item);
            string month = DateTOMonthString(item.StartTime);
            string date = DateTODateString(item.StartTime);
            CollectionList[month].AddItem(item);
            CollectionList[date].AddItem(item);
        }
        public void LoadData(List<IWorkItem> itemlist)
        {

            foreach (var item in itemlist)
            {
                AddItem(item);
            }
        }

        public IWorkItem GetItem(Guid id)
        {
            return TotalCollection.GetItem(id);
        }
        public List<IWorkItem> ReadItemList()
        {
            return TotalCollection.ReadItemList();
        }
        public void UpdateItem(Guid id, IWorkItem item)
        {
            TotalCollection.UpdateItem(id, item);
            var workitem = TotalCollection.GetItem(id);
            string month = DateTOMonthString(workitem.StartTime);
            string date = DateTODateString(workitem.StartTime);
            CollectionList[date].UpdateItem(id, item);
            CollectionList[month].UpdateItem(id, item);



        }
        public void DeleteItem(Guid id)
        {
            TotalCollection.DeleteItem(id);
            var workitem = TotalCollection.GetItem(id);
            string month = DateTOMonthString(workitem.StartTime);
            string date = DateTODateString(workitem.StartTime);
            CollectionList[date].DeleteItem(id);
            CollectionList[month].DeleteItem(id);
        }
        public void ClearItemList()
        {
            TotalCollection.ClearItemList();
        }

        private string DateTOMonthString(DateTime date)
        {
            return date.ToString("yyyy/MM");
        }
        private string DateTODateString(DateTime date)
        {
            return date.ToString("yyyy/MM//dd");
        }

    }
}

