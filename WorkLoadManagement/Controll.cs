using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

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
        public Dictionary<DateTime,TimeSpan> MonthlyWorkTime { get; set; }
        public Dictionary<DateTime,TimeSpan> WeaklyWorkTime { get; set; }
        public WorkDataController WorkDataController
        {
            get
            {
                return dataController;
            }
        }
        public WorkDataList WorkDataList
        {
            get
            {
                return workDataList;
            }
            private set
            { }
        }


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
        public void AnalizeCalc()
        {
            dataController.Calc();
            //todo:monthly calcなどもここで実行
        }

        static string Serialize<T>(T value)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var serializedData = string.Empty;
            using (var memoryStream = new MemoryStream())
            {
                serializer.WriteObject(memoryStream, value);
                serializedData = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            return serializedData;
        }


    }

    
}
