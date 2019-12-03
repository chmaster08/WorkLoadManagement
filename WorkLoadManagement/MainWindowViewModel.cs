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
    public class MainWindowViewModel
    {
        private Control mycontrol;

        public MainWindowViewModel(Control control)
        {
            mycontrol = control;
            mycontrol.Input();
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
            mycontrol.Output();
            mycontrol.GetWorkDataList();
            AnalizeViewModel viewModel = new AnalizeViewModel(mycontrol);
            Analize view = new Analize(viewModel);
            view.Owner = Application.Current.MainWindow;
            view.ShowDialog();

            //統計データ表示画面
        }
    }
}
