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
            WorkCodeList = new List<string>();
        }

        public List<string> WorkCodeList { get; set; }


        public void InitializeGetWorkItem()
        {

            
        }



        public void SetWorkData(WorkItem item)
        {
            dataController.Add(item);
        }

        public void Output()
        {
            try
            {
                string output = JsonConvert.SerializeObject(workDataList);
                File.WriteAllText(@"C:\Users\e13498\Output.data", output);
            }
            catch 
            { }
        }

        public void Input()
        {
            if (File.Exists(@"C:\Users\e13498\Output.data"))
            {
                string input = File.ReadAllText(@"C:\Users\e13498\Output.data");
                var deserialized = JsonConvert.DeserializeObject<WorkDataList>(input);
                dataController.Import(deserialized);
                ImportCodeList(workDataList);

            }

        }

        private void ImportCodeList(WorkDataList itemlist)
        {
            foreach(var item in itemlist.workcodelist)
            {
                WorkCodeList.Add(item);
            }
        }

        
    }

    
}
