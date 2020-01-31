using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore.Interface
{
    interface IImport
    {
        List<WorkItem> GetAllItems();
        List<WorkItem> GetMonthlyItems(int month);
        List<WorkItem> GetNewestSomeItems(int amount);
    }
}
