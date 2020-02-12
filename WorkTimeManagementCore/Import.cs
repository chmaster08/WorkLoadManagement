using System;
using System.Collections.Generic;
using System.Text;
using WorkTimeManagementCore.Interface;

namespace WorkTimeManagementCore
{

    
    public class ImportData
    {
        private IImport importfunc;
        private IImport localimport;
        private List<IWorkItem> importitemlist;
        public ImportData(List<IWorkItem> itemlist,IImport import)
        {
            importfunc = import;
            importitemlist = itemlist;
        }

        public void InitialImport()
        {
            importitemlist=importfunc.GetAllItems();
        }
    }

    public class ImportFromAWS : IImport
    {
        public ImportFromAWS()
        {

        }
        public List<IWorkItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public List<IWorkItem> GetMonthlyItems(int month)
        {
            throw new NotImplementedException();
        }

        public List<IWorkItem> GetNewestSomeItems(int amount)
        {
            throw new NotImplementedException();
        }
    }

    public class ImportFromLocal : IImport
    {
        private string codepath = @"C:\Users\" + Environment.UserName + @"\CodeOutput.data";
        private string datapath = @"C:\Users\" + Environment.UserName + @"\DataOutput.data";
        public ImportFromLocal()
        {

        }
        public List<IWorkItem> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public List<IWorkItem> GetMonthlyItems(int month)
        {
            throw new NotImplementedException();
        }

        public List<IWorkItem> GetNewestSomeItems(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
