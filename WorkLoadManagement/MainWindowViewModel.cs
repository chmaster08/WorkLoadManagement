using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
namespace WorkLoadManagement
{
    public class MainWindowViewModel:ViewModelBase
    {
        private Control mycontrol;
        private bool isLoaded=false;

        public MainWindowViewModel(Control control)
        {
            mycontrol = control;
            Task AWSTask = new Task(LoadData);
            AWSTask.Start();
            //local test用
            //mycontrol.Input();
        }

        public bool IsLoaded
        {
            get
            {
                return isLoaded;
            }
            set
            {
                isLoaded = value;
                OnPropertyChanged("IsLoaded");
            }
        }

        public void LoadData()
        {
            mycontrol.GetAWSData();
            IsLoaded = true;
        }

        public void OpenNewWorkView()
        {
            RegisterWorkViewModel viewModel = new RegisterWorkViewModel(mycontrol);
            RegisterWorkView view = new RegisterWorkView(viewModel);
            view.Owner = Application.Current.MainWindow;
            view.ShowDialog();
            //データ登録画面
        }

        public void OpenDataView()
        {
            //localに一応保存。次回にデータベースと差異がある場合更新
            mycontrol.Output();
            AnalizeViewModel viewModel = new AnalizeViewModel(mycontrol);
            Analize view = new Analize(viewModel);
            view.Owner = Application.Current.MainWindow;
            view.ShowDialog();

            //統計データ表示画面
        }

    }
}
