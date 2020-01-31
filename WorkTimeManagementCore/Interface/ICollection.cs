using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore
{
    interface ICollection
    {
        void AddItem(WorkItem item);
        WorkItem GetItem(Guid id);
        List<WorkItem> ReadItemList();
        void UpdateItem(Guid id);
        void DeleteItem(Guid id);
        void ClearItemList();
    }
}
