using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class AnalizeViewModel
    {
        private Control mycontrol;
        private ObservableCollection<WorkItem> workdatalist;

        public AnalizeViewModel(Control control)
        {
            mycontrol = control;
        }

        public void LoadWorkDataList()
        {
        }

        public ObservableCollection<WorkItem> WorkDataList
        {
            
        }
    }
}
