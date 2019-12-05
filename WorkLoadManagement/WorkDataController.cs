using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class WorkDataController
    {
        private WorkDataList WorkDataList;
        private WorkCodeList workCodeList;
        public WorkDataController(WorkDataList dataList, WorkCodeList codelist)
        {
            WorkDataList = dataList;
            workCodeList = codelist;
        }

        public void Add(WorkItem item)
        {
            WorkDataList.itemList.Add(item);
            workCodeList.Add(item.workCode);
            
        }
        public WorkDataList GetWorkDataList()
        {
            return WorkDataList;
        }
       

        public void ImportWorkData(WorkDataList itemlist)
        {
            AddList(itemlist);
        }

        public void ImportWorkCode(WorkCodeList itemlist)
        {
            AddList(itemlist);
        }

        public void AddList(WorkDataList itemlist)
        {
            foreach(var item in itemlist.itemList)
            {
                WorkDataList.itemList.Add(item);
            }
        }
        public void AddList(WorkCodeList itemlist)
        {
            foreach (var item in itemlist.workCodeList)
            {
                workCodeList.Add(item);
            }
        }



        public void SetData(WorkItem item)
        {

        }
        public TimeSpan GetTotalTime()
        {
            return WorkDataList.totaltime;
        }
        public TimeSpan GetTotalTime(string workcode)
        {
            return WorkDataList.workcodetime[workcode];
        }
        public Dictionary<string,TimeSpan> GetWorkCodeTimeList()
        {
            return WorkDataList.workcodetime;
        }

        public virtual void Calc()
        {
            var itemList = WorkDataList.itemList;
            foreach (var item in itemList)
            {
                WorkDataList.totaltime += item.GetWorkTime();
            }
            foreach (var item in itemList)
            {
                if (WorkDataList.workcodetime.ContainsKey(item.workCode))
                {
                    WorkDataList.workcodetime[item.workCode] += item.GetWorkTime();
                }
                else
                {
                    WorkDataList.workcodetime.Add(item.workCode, item.GetWorkTime());
                }
            }
        }
    }
}
