using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class Control
    {
        private WorkDataList workDataList;
        private WorkDataController dataController;

        public Control()
        {
            workDataList = new WorkDataList();
            dataController = new WorkDataController(workDataList);
        }

        public void InitializeGetWorkItem()
        {
            
        }



        public void SetWorkData(WorkItem item)
        {
            dataController.Add(item);
        }

        
    }

    
}
