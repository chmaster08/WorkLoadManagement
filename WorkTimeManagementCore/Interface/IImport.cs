using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore.Interface
{
    public interface IImport
    {
        List<IWorkItem> GetAllItems();
        List<IWorkItem> GetMonthlyItems(int month);
        List<IWorkItem> GetNewestSomeItems(int amount);
    }
}
