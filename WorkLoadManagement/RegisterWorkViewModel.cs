using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    public class RegisterWorkViewModel
    {
        private Control mycontrol;
        private WorkItem workitem;
        private DateTime starttime;
        private DateTime endtime;
        private string comment;
        private TestList mytestlist = new TestList();
        private ObservableCollection<string> testlist;
        private int itemindex;
        public RegisterWorkViewModel(Control control)
        {
            mycontrol = control;
            Initialize();
        }

        public ObservableCollection<string> MyTestList
        {
            get
            {
                return testlist;
            }
        }
        public int ItemIndex
        {
            get
            {
                return itemindex;
            }
            set
            {
                itemindex = value;
            }
        }

        public DateTime StartTime
        {
            get
            {
                return starttime;
            }
            set
            {
                starttime = value;
            }
        }
        public DateTime EndTime
        {
            get
            {
                return endtime;
            }
            set
            {
                endtime = value;
            }
        }

        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
            }
        }



        private void Initialize()
        {
            LoadWorkCode();
            starttime = DateTime.Now;
            endtime = DateTime.Now;
        }

        private void LoadWorkCode()
        {
            testlist = new ObservableCollection<string>();
            testlist.Add("test1");
            testlist.Add("test2");
            testlist.Add("test3");

        }

        public void SetWorkData()
        {
            workitem = new WorkItem();
            workitem.StartTime = starttime;
            workitem.EndTime = endtime;
            workitem.workCode = testlist[itemindex];
            workitem.Comment = comment;
            mycontrol.SetWorkData(workitem);
        }


    }
}
