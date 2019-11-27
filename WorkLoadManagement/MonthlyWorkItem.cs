using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class MonthlyWorkItem : IWorkDataList
    {
        private List<WorkItem> itemList;

        private TimeSpan totaltime;
        private List<string> workcodelist;
        private Dictionary<string, TimeSpan> workcodetime;

        public MonthlyWorkItem(DateTime dateTime)
        {
            //月を指定できるように
            Calc();  
        }

        public void Calc()
        {
            foreach (var item in itemList)
            {
                totaltime += item.GetWorkTime();
            }
            foreach (var item in itemList)
            {
                workcodelist.Add(item.workCode);
            }
            foreach (var item in itemList)
            {
                if (workcodetime.ContainsKey(item.workCode))
                {
                    workcodetime[item.workCode] += item.GetWorkTime();
                }
                else
                {
                    workcodetime.Add(item.workCode, item.GetWorkTime());
                }
            }
        }

        public TimeSpan GetTotalTime()
        {
            if(totaltime!=null)
            {
                return totaltime;
            }
            else
            {
                throw new Exception("Nodata");
            }
        }

        public TimeSpan GetTotalTime(string workcode)
        {
            return workcodetime[workcode];
            throw new NotImplementedException();
        }
    }
}
