using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class MonthlyDataController :WorkDataController
    {
        private WorkDataList WorkDataList;
        private int Monthlydate;


        public MonthlyDataController(WorkDataList dataList,int month)
            :base(dataList)
        {
            WorkDataList = dataList;
            Monthlydate = month;
        }
        public override void Calc()
        {
            var itemList = WorkDataList.itemList.Where(item=>item.CreateTime.Month==Monthlydate);
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
