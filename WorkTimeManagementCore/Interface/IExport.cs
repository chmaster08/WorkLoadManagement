using System;
using System.Collections.Generic;
using System.Text;

namespace WorkTimeManagementCore.Interface
{
    interface IExport
    {
        void ExportAll();
        void ExportDiff();
        void ExportItem(WorkItem item);
    }
}
