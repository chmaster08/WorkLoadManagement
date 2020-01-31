using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkTimeManagementCore.Interface;

namespace WorkTimeManagementCore
{
    public class CollectionController
    {
        private bool isExistMonthlyCollection;
        private bool isExistDaylyCollection;
        public CollectionController()
        {

        }

        public List<ICollection> CollectionList { get; set; }

        public void AddItem(IWorkItem item)
        {
            throw new NotImplementedException();
        }

        public void AddItemList(List<IWorkItem> itemlist)
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

        public void RegisterCollection(ICollection collection)
        {
        }

        public void UpdateItem(Guid id, IWorkItem item)
        {
            throw new NotImplementedException();
        }
        private void isExistCollection(ICollection collection)
        {
            if (CollectionList.Where(list => list is MonthlyCollection).Any(item => item.Date.Month == collection.Date.Month))
            {
                isExistMonthlyCollection = true;
            }
            else
            {
                isExistMonthlyCollection = false;
            }
            if (CollectionList.Where(list => list is DaylyCollection).Any(item => item.Date.Date == collection.Date.Date))
            {
                isExistDaylyCollection = true;
            }
            else
            {
                isExistDaylyCollection = false;
            }

        }
    }
}
