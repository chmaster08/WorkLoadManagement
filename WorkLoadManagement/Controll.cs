using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon;
using System.Windows;

namespace WorkLoadManagement
{
    public class Control
    {
        private WorkDataList workDataList;
        private WorkCodeList workCodeList;
        private List<MonthlyWorkCodeTime> monthlyWorkCodeTimes;
        private AmazonDynamoDBClient client;
        private ImportWorkDB myImport;
        private string codepath = @"C:\Users\" + Environment.UserName + @"\CodeOutput.data";
        private string datapath = @"C:\Users\" + Environment.UserName + @"\DataOutput.data";


        public Control()
        {
            workCodeList = new WorkCodeList();
            workDataList = new WorkDataList();
            monthlyWorkCodeTimes = new List<MonthlyWorkCodeTime>();
            
        }

        
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
        public AmazonDynamoDBClient Client
        {
            get
            {
                return client;
            }
        }
       

        public void InitializeGetWorkItem()
        {

            
        }

        public void GetAWSData()
        {
            try
            {
                AWSSetting();
                myImport = new ImportWorkDB(this);
                myImport.ImportData();
            }
            catch
            {
                ShowWarningWindow("Failed to Connect to AWS");
            }
            AnalizeCalc();

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
        }

        public void Output()
        {
            OutputWorkData();
            OutputWorkCode();
        }
        public void SingleCalc(WorkItem item)
        {
            var mycontroller = new MonthlyWorkCodeController(monthlyWorkCodeTimes);
            mycontroller.Add(item);
            

        }

        public void AWSSetting()
        {
            try
            {
                client = new AmazonDynamoDBClient(RegionEndpoint.USEast2);
                //CreateTables();

            }
            catch(Exception ex)
            {
                throw new Exception("AWS Client Error:"+ex.Message);
            }

        }
        public void AddWorkItemToAWS(WorkItem item)
        {
            var table = Amazon.DynamoDBv2.DocumentModel.Table.LoadTable(client, "WorkItemList");
            Document document = new Document();
            document["ID"] = item.ID;
            document["StartTime"] = item.StartTime;
            document["EndTime"] = item.EndTime;
            document["CreateTime"] = item.CreateTime;
            document["workCode"] = item.workCode;
            document["Comment"] = item.Comment;
            table.PutItem(document);

        }

        public void ShowWarningWindow(List<string> stringlist)
        {
            Warning view = new Warning(stringlist);
            view.Owner = Application.Current.MainWindow;
            view.ShowDialog();
        }
        public void ShowWarningWindow(string strings)
        {
            Warning view = new Warning(strings);
            view.Owner = Application.Current.MainWindow;
            view.ShowDialog();
        }


        private void CreateTables()
        {
            List<string> currentTables = client.ListTables().TableNames;
            if(!currentTables.Contains("WorkItemList"))
            {
                CreateTableRequest createTableRequest = new CreateTableRequest
                {
                    TableName = "WorkItemList",
                    AttributeDefinitions = new List<AttributeDefinition>()
                {
                    new AttributeDefinition
                    {
                        AttributeName = "Id",
                        AttributeType = "N"
                    },
                    new AttributeDefinition
                    {
                        AttributeName = "Name",
                        AttributeType = "S"
                    }
                },
                    KeySchema = new List<KeySchemaElement>()
                {
                    new KeySchemaElement
                    {
                        AttributeName = "Id",
                        KeyType = "HASH"
                    },
                    new KeySchemaElement
                    {
                        AttributeName = "Name",
                        KeyType = "RANGE"
                    }
                },

                };
                createTableRequest.ProvisionedThroughput = new ProvisionedThroughput(1, 1);

                CreateTableResponse createResponse;
                try
                {
                    createResponse = client.CreateTable(createTableRequest);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("Error: failed to create the new table; " + ex.Message);

                    return;
                }
            }
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
