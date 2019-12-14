using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class MonthlyWorkCodeTime
    {
        public MonthlyWorkCodeTime(WorkItem item)
        {
            Year = item.StartTime.Year;
            Month = item.StartTime.Month;
            WorkCode = item.workCode;
            WorkTime = item.GetWorkTime();

        }
        public int Year { get; set; }
        public int Month { get; set; }
        public string WorkCode { get; set; }
        public TimeSpan WorkTime { get; set; }
    }

    public class MonthlyWorkCodeController
    {
        private List<MonthlyWorkCodeTime> mylist;
        public MonthlyWorkCodeController(List<MonthlyWorkCodeTime> itemlist)
        {
            mylist = itemlist;

        }

        public void Add(WorkItem item)
        {
            int index = 0;
            if(IsExit(item.StartTime.Year, item.StartTime.Month,item.workCode,out index))
            {
                mylist[index].WorkTime += item.GetWorkTime();
                
            }
            else
            {
                mylist.Add(new MonthlyWorkCodeTime(item));
            }

        }


        private bool IsExit(int year,int month,string code,out int index)
        {
            int i = 0;
            foreach(var item in mylist)
            {
                if (item.Year==year & item.Month==month & item.WorkCode==code)
                {
                    index = i;
                    return true;
                }
                i++;

            }
            index = 0;
            return false;
            

        }
    }
}
