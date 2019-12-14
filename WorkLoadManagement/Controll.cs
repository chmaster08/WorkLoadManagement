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
        private List<MonthlyWorkCodeTime> monthlyWorkCodeTimes;
        private string codepath = @"C:\Users\" + Environment.UserName + @"\CodeOutput.data";
        private string datapath = @"C:\Users\" + Environment.UserName + @"\DataOutput.data";


        public Control()
        {
            workCodeList = new WorkCodeList();
            workDataList = new WorkDataList();
            monthlyWorkCodeTimes = new List<MonthlyWorkCodeTime>();
        }

        
        public Dictionary<DateTime,TimeSpan> MonthlyWorkTime { get; set; }
        public Dictionary<DateTime,TimeSpan> WeaklyWorkTime { get; set; }
        
        public WorkDataList WorkDataList
        {
            get
            {
                return workDataList;
            }
            
        }
        public WorkCodeList WorkCodeList
        {
            get
            {
                return workCodeList;
            }
        }
        public List<MonthlyWorkCodeTime> MonthlyWorkCodeTimes
        {
            get
            {
                return monthlyWorkCodeTimes;
            }
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


        public void SetWorkData(WorkItem item)
        {
            workDataList.itemList.Add(item);
            workCodeList.Add(item.workCode);

        }
        public void AnalizeCalc()
        {
            MonthlyCalc();
            //todo:monthly calcなどもここで実行
        }

        public void Output()
        {
            OutputWorkData();
            OutputWorkCode();
        }
        public void Input()
        {
            InputWorkData();
            InputWorkCode();

        }
        private void ImportWorkData(WorkDataList itemlist)
        {
            foreach (var item in itemlist.itemList)
            {
                workDataList.itemList.Add(item);
            }
        }

        private void ImportWorkCode(WorkCodeList itemlist)
        {
            foreach (var item in itemlist.workCodeList)
            {
                workCodeList.Add(item);
            }
        }


        private void OutputWorkData()
        {
            try
            {
                string output = JsonConvert.SerializeObject(workDataList);
                File.WriteAllText(datapath, output);
            }
            catch 
            { }
        }
        private void OutputWorkCode()
        {
            try
            {
                string output = JsonConvert.SerializeObject(workCodeList);
                File.WriteAllText(codepath, output);
            }
            catch
            { }
        }

        
        private void InputWorkData()
        {
            if (File.Exists(datapath))
            {
                string input = File.ReadAllText(datapath);
                var deserialized = JsonConvert.DeserializeObject<WorkDataList>(input);
                ImportWorkData(deserialized);

            }

        }
        private void InputWorkCode()
        {
            if (File.Exists(codepath))
            {
                string input = File.ReadAllText(codepath);
                var deserialized = JsonConvert.DeserializeObject<WorkCodeList>(input);
                ImportWorkCode(deserialized);

            }

        }

        private void MonthlyCalc()
        {
            var mycontroller = new MonthlyWorkCodeController(monthlyWorkCodeTimes);
            foreach(var item in workDataList.itemList)
            {
                mycontroller.Add(item);
            }
        }
        


    }

    
}
