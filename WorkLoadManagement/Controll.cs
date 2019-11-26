using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class Control
    {
        private WorkItem myitem;

        public void SetWorkData(WorkItem item)
        {
            myitem = new WorkItem();
            myitem = item;
        }

    }

    
}
