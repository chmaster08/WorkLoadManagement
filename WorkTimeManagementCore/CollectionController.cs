using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkTimeManagementCore.Interface;

namespace WorkTimeManagementCore
{
    public class CollectionController
    {

        private bool istotalexist = false;
        public CollectionController()
        {
            CollectionList = new List<ICollection>();
        }


        public List<ICollection> CollectionList { get; set; }

        public void AddItem(IWorkItem item)
        {
            
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
            switch (collection.CollectionType)
            {
                case Collections.Dayly:
                    if(!CollectionList.Where(item=>item.CollectionType==Collections.Dayly).Any(item => item.Date==collection.Date.Date))
                    {
                        CollectionList.Add(collection);
                    }
                    break;
                case Collections.Monthly:
                    if(!CollectionList.Where(item => item.CollectionType==Collections.Monthly).Any(item => item.Date.Month==collection.Date.Month))
                    {
                        CollectionList.Add(collection);
                    }
                    break;
                case Collections.Total:
                    if(!istotalexist)
                    {
                        CollectionList.Add(collection);
                        istotalexist = true;
                    }
                    break;
            }

        }

        public void UpdateItem(Guid id, IWorkItem item)
        {
            throw new NotImplementedException();
        }
        
    }
}
