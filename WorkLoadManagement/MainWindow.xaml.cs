using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorkLoadManagement
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        MainWindowViewModel myViewModel;


        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            myViewModel = viewModel;
            this.DataContext =myViewModel;
        }

        private void BtnNew_Click(object sender,RoutedEventArgs e)
        {
            myViewModel.OpenNewWorkView();

        }

        private void BtnData_Click(object sender,RoutedEventArgs e)
        {
            myViewModel.OpenDataView();
        }
    }
}
