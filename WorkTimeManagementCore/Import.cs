using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore
{
    public class ImportFromAWS : IImport
    {
        public ImportFromAWS()
        {

        }
        public List<WorkItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public List<WorkItem> GetMonthlyItems(int month)
        {
            throw new NotImplementedException();
        }

        public List<WorkItem> GetNewestSomeItems(int amount)
        {
            throw new NotImplementedException();
        }
    }

    public class ImportFromLocal : IImport
    {
        public ImportFromLocal()
        {

        }
        public List<WorkItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public List<WorkItem> GetMonthlyItems(int month)
        {
            throw new NotImplementedException();
        }

        public List<WorkItem> GetNewestSomeItems(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
