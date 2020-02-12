using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore
{
    public class Control
    {

        private List<IWorkItem> workItemList;
        private CollectionController collectionController;
        private string codepath = @"C:\Users\" + Environment.UserName + @"\CodeOutput.data";
        private string datapath = @"C:\Users\" + Environment.UserName + @"\DataOutput.data";

        public Control()
        {
            workItemList = new List<IWorkItem>();
            collectionController = new CollectionController();


        }

        public void Initialize()
        {
            ImportData();
            collectionController.LoadData(workItemList);

        }

        public void ImportData()
        {

        }

        


    }
}
