using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore.Interface
{
    public enum Collections
    {
        Total,
        Monthly,
        Dayly
    }
    public interface ICollection
    {
        Collections CollectionType { get;}
        DateTime Date { get; set; }
        void AddItem(IWorkItem item);
        void AddItemList(List<IWorkItem> workItemList);
        IWorkItem GetItem(Guid id);
        List<IWorkItem> ReadItemList();
        void UpdateItem(Guid id,IWorkItem item);
        void DeleteItem(Guid id);
        void ClearItemList();
    }
}
