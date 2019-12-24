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
    /// Warning.xaml の相互作用ロジック
    /// </summary>
    public partial class Warning : Window
    {
        private List<string> erromsg;
        private string outmsg;

        public Warning(List<string> message)
        {
            InitializeComponent();
            erromsg = message;
            ListToString();
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            this.EMsg.Text = outmsg;
        }
        public Warning(string message)
        {
            InitializeComponent();
            outmsg = message;
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
            this.EMsg.Text = outmsg;
        }
        public string ErrorMsg
        {
            get
            {
                return outmsg;
            }
        }


        private void Btn_OKClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ListToString()
        {
            var longletter=string.Empty;
            foreach(var item  in erromsg)
            {
                longletter += (item + "\n");
            }
            outmsg = longletter;
        }
    }
}
