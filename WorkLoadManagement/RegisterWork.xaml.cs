using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WorkLoadManagement
{
    /// <summary>
    /// RegisterWorkView.xaml の相互作用ロジック
    /// </summary>
    public partial class RegisterWorkView : Window
    {
        private RegisterWorkViewModel myViewModel;
        public RegisterWorkView(RegisterWorkViewModel viewModel)
        {
            InitializeComponent();
            myViewModel=viewModel;
            this.DataContext = myViewModel;
        }

        private void BtnOKClick(object sender,RoutedEventArgs e)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            myViewModel.SetWorkData();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;

            if(!myViewModel.IsExitError)
            {
                this.Close();
            }
        }

        private void BtnCancelClick(object sender,RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGetPresentTime(object sender, RoutedEventArgs e)
        {
            myViewModel.RefreshEndTime();
            //WorkCode 新規追加
        }
    }
}
