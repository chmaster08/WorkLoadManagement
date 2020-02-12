using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore
{
    public class Control
    {

        private List<IWorkItem> workItemList;
        private CollectionController collectionController;
        private ImportData myImportData;
        

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
            try
            {
                myImportData = new ImportData(workItemList, new ImportFromAWS());
                myImportData.InitialImport();
            }
            catch
            {
                myImportData = new ImportData(workItemList, new ImportFromLocal());
                myImportData.InitialImport();
            }
        }



        


    }
}
