using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkLoadManagement
{
    internal static class WorkLoadManagement
    {
        [STAThread]
        private static void Main()
        {
            App application = new App();
            Control control = new Control();
            MainWindowViewModel mainWindowView = new MainWindowViewModel(control);
            MainWindow mainWindow = new MainWindow(mainWindowView);
            application.Run(mainWindow);

        }

    }
}
