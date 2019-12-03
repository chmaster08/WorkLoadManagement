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
            workdatalist = new ObservableCollection<WorkItem>();
            LoadWorkDataList();
        }

        private void LoadWorkDataList()
        {
            foreach(var item in mycontrol.WorkDataList)
            {
                workdatalist.Add(item);
            }
        }

        public ObservableCollection<WorkItem> WorkDataList
        {
            get
            {
                return workdatalist;
            }
            
        }
    }
}
