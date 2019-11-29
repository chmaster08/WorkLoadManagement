using Newtonsoft.Json;
using System;
using System.IO;
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

        public void Output()
        {
            string output = JsonConvert.SerializeObject(workDataList);
            File.WriteAllText(@"C:\Users\e13498\Documents\WorkManager\Output.data",output);
        }

        public void Input()
        {
            string input = File.ReadAllText(@"C:\Users\e13498\WorkManager\Output.data");
            var deserialized = JsonConvert.DeserializeObject<WorkDataList>(input);
            dataController.AddList(deserialized);
        }

        
    }

    
}
