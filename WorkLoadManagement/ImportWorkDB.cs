using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class ImportWorkDB
    {
        private Control mycontrol;
        private AmazonDynamoDBClient client;
        private string codepath = @"C:\Users\" + Environment.UserName + @"\CodeOutput.data";
        private string datapath = @"C:\Users\" + Environment.UserName + @"\DataOutput.data";


        public ImportWorkDB(Control control)
        {
            mycontrol = control;
            client = mycontrol.Client;
        }

        class ListCompetetor: EqualityComparer<WorkItem>
        {
            public override bool Equals(WorkItem w1, WorkItem w2)
            {
                return (w1.ID == w2.ID);
            }
            public override int GetHashCode(WorkItem w)
            {
                return w.ID.GetHashCode();
            }
        }
        public void ImportData()
        {
            List<WorkItem> AWSlist,Locallist;
            try
            {
                AWSlist = ImportDataFromAWS();
                Locallist = ImportDataFromLocal();
            }
            catch
            {
                Warning view = new Warning("AWS Connection Error");
                view.Owner = System.Windows.Application.Current.MainWindow;
                view.ShowDialog();
                AWSlist = new List<WorkItem>();
                Locallist = new List<WorkItem>();
            }
            var comp = new ListCompetetor();
            bool IsEqual = AWSlist.SequenceEqual(Locallist,comp);
            
            if (!IsEqual)
            {
                var LocalminusAWS = Locallist.Except(AWSlist, comp);
                if(LocalminusAWS.Any())
                {
                    AWSlist.AddRange(LocalminusAWS);
                }


            }
            foreach (var item in AWSlist)
            {
                mycontrol.SetWorkData(item);
            }
        }

        private List<WorkItem> ImportDataFromAWS()
        {
            var request = new ScanRequest
            {
                TableName = "WorkItemList",

            };

            var table = Amazon.DynamoDBv2.DocumentModel.Table.LoadTable(client, "WorkItemList");
            var search = table.Scan(new Amazon.DynamoDBv2.DocumentModel.Expression());
            var documentlist = new List<Document>();
            var AWSWorkItemList = new List<WorkItem>();
            do
            {
                documentlist.AddRange(search.GetNextSet());
            } while (!search.IsDone);

            foreach (var doc in documentlist)
            {
                var item = new WorkItem();
                foreach (var attr in doc.GetAttributeNames())
                {
                    var value = doc[attr];
                    if (attr == "StartTime")
                    {
                        item.StartTime = DateTime.Parse(doc[attr]);
                    }
                    else if (attr == "EndTime")
                    {
                        item.EndTime = DateTime.Parse(doc[attr]);
                    }
                    else if (attr == "workCode")
                    {
                        item.workCode = doc[attr];
                    }
                    else if (attr == "Comment")
                    {
                        item.Comment = doc[attr];
                    }
                    else if (attr == "CreateTime")
                    {
                        item.CreateTime = DateTime.Parse(doc[attr]);
                    }
                    else if (attr == "ID")
                    {
                        item.ID = Guid.Parse(doc[attr]);
                    }
                }
                AWSWorkItemList.Add(item);
            }
            return AWSWorkItemList;

        }

        private List<WorkItem> ImportDataFromLocal()
        {
            var locallist = InputWorkData();
            return locallist;

        }
        private List<WorkItem> InputWorkData()
        {
            var locallist = new List<WorkItem>();

            if (File.Exists(datapath))
            {
                string input = File.ReadAllText(datapath);
                var deserialized = JsonConvert.DeserializeObject<WorkDataList>(input);
                locallist.AddRange(deserialized.itemList);
            }
            return locallist;


        }

    }
}
