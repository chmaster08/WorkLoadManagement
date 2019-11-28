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
        public WorkDataController(WorkDataList dataList)
        {
            WorkDataList = dataList;
        }

        public void Add(WorkItem item)
        {
            WorkDataList.itemList.Add(item);
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

        private void Calc()
        {
            var itemList = WorkDataList.itemList;
            foreach (var item in itemList)
            {
                WorkDataList.totaltime += item.GetWorkTime();
            }
            foreach (var item in itemList)
            {
                WorkDataList.workcodelist.Add(item.workCode);
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
