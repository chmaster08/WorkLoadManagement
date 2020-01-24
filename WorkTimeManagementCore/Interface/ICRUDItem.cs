using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore
{
    interface ICRUDItem
    {
        void CreateItem();
        WorkItem GetItem(Guid id);
        List<WorkItem> ReadItems();
        void UpdateItem(Guid id);
        void DeleteItem(Guid id);
        void DeleteAllItems();
    }
}
