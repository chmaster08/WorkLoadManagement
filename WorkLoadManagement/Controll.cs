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
        private WorkCodeList workCodeList;
        private WorkDataController dataController;


        public Control()
        {
            workCodeList = new WorkCodeList();
            workDataList = new WorkDataList();
            dataController = new WorkDataController(workDataList,workCodeList);
        }

        public List<string> WorkCodeList { get; set; }


        public void InitializeGetWorkItem()
        {

            
        }

        public void SetWorkCodeToList(string item)
        {
            if(!workCodeList.FindCode(item))
            {
                workCodeList.Add(item);
            }
        }

        public void GetWorkCodeList()
        {
            WorkCodeList = new List<string>();
            foreach(var item in workCodeList.workCodeList)
            {
                WorkCodeList.Add(item);
            }
        }

        public void SetWorkData(WorkItem item)
        {
            dataController.Add(item);
        }

        public void Output()
        {
            OutputWorkData();
            OutputWorkCode();
        }

        private void OutputWorkData()
        {
            try
            {
                string output = JsonConvert.SerializeObject(workDataList);
                File.WriteAllText(@"C:\Users\e13498\WorkOutput.data", output);
            }
            catch 
            { }
        }
        private void OutputWorkCode()
        {
            try
            {
                string output = JsonConvert.SerializeObject(workCodeList);
                File.WriteAllText(@"C:\Users\e13498\CodeOutput.data", output);
            }
            catch
            { }
        }

        public void Input()
        {
            InputWorkData();
            InputWorkCode();

        }
        private void InputWorkData()
        {
            if (File.Exists(@"C:\Users\e13498\WorkOutput.data"))
            {
                string input = File.ReadAllText(@"C:\Users\e13498\WorkOutput.data");
                var deserialized = JsonConvert.DeserializeObject<WorkDataList>(input);
                dataController.ImportWorkData(deserialized);

            }

        }
        private void InputWorkCode()
        {
            if (File.Exists(@"C:\Users\e13498\CodeOutput.data"))
            {
                string input = File.ReadAllText(@"C:\Users\e13498\CodeOutput.data");
                var deserialized = JsonConvert.DeserializeObject<WorkCodeList>(input);
                dataController.ImportWorkCode(deserialized);

            }

        }

        
    }

    
}
