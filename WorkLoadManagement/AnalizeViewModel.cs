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
            _PlotModel = new PlotModel() { Title = "開発コードごとの工数" };

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


            var datalist = mycontrol.WorkDataController.GetWorkCodeTimeList();
            foreach(var item in datalist)
            {
                series.Slices.Add(new PieSlice(item.Key, item.Value.TotalMinutes));
            }

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
        public TimeSpan TotalTime { get; set; }
    }
}
