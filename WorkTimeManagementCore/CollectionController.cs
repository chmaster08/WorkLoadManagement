using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkTimeManagementCore.Interface;

namespace WorkTimeManagementCore
{
    public class CollectionController
    {
        public CollectionController()
        {
            CollectionList = new Dictionary<Collections, ICollection>();
        }

        public Dictionary<Collections, ICollection> CollectionList { get; set; }

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
        
    }
}
