using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public interface IWorkDataList
    {
        void SetData(WorkItem item);
        TimeSpan GetTotalTime();
        TimeSpan GetTotalTime(string workcode);
        void Calc();
    }
}
