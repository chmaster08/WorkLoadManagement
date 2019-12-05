using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private string newcode;
        private ObservableCollection<string> workcodelist;
        private string itemindex;

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterWorkViewModel(Control control)
        {
            mycontrol = control;
            workcodelist = new ObservableCollection<string>();
            Initialize();

        }

        private void Initialize()
        {
            mycontrol.GetWorkCodeList();
            LoadWorkCode();
            starttime = DateTime.Now;
            endtime = DateTime.Now;
        }

        private void LoadWorkCode()
        {
            for(int i=0;i<mycontrol.WorkCodeList.Count;i++)
            {
                workcodelist.Add(mycontrol.WorkCodeList[i]);
            }
        }

        public void SetWorkData()
        {
            Check_value();
            workitem = new WorkItem();
            workitem.StartTime = starttime;
            workitem.EndTime = endtime;
            workitem.workCode = itemindex;
            workitem.Comment = comment;
            mycontrol.SetWorkData(workitem);
        }

        private void Check_value()
        {
            TimeSpan time = endtime - starttime;
            if(time <= new TimeSpan(0))
            {
                //Error Dialog
            }


        }

        public ObservableCollection<string> WorkCodeList
        {
            get
            {
                return workcodelist;
            }
        }
        public string ItemIndex
        {
            get
            {
                return itemindex;
            }
            set
            {
                itemindex = value;
                OnPropertyChanged("ItemIndex");
            }
        }

        public string InputCode
        {
            set
            {
                newcode = value;
                workcodelist.Add(newcode);
                mycontrol.SetWorkCodeToList(newcode);
                itemindex = value;
                OnPropertyChanged("WorkCodeList");
                OnPropertyChanged("ItemIndex");

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




        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler!=null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
