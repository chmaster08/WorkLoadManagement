using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore.Interface
{
    public interface ICollection
    {
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
