using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Wpf;
using OxyPlot.Series;

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
            LoadGraphData();
        }

        private void LoadWorkDataList()
        {
            foreach(var item in mycontrol.WorkDataList)
            {
                workdatalist.Add(item);
            }
        }
        public void LoadGraphData()
        {
            Datalist = new List<DataPoint>();
            _PlotModel = new PlotModel() { Title = "PieChart" };

            Datalist.Add(new DataPoint(1, 2));
            Datalist.Add(new DataPoint(1, 2));
            Datalist.Add(new DataPoint(2, 3));

            var series = new OxyPlot.Series.PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.5,
                AngleSpan = 360,
                StartAngle = 270,
            };

            series.Slices.Add(new PieSlice("Hathor", 7508));
            series.Slices.Add(new PieSlice("CM-CT1", 6125));
            series.Slices.Add(new PieSlice("Other", 4346));
            series.Slices.Add(new PieSlice("None", 1778));

            _PlotModel.Series.Add(series);

        }

        public ObservableCollection<WorkItem> WorkDataList
        {
            get
            {
                return workdatalist;
            }
            
        }

        public List<DataPoint> Datalist { get; set; }
        public PlotModel _PlotModel { get; private set; } 
    }
}
