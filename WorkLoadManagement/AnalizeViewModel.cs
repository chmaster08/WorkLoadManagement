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
        private ObservableCollection<Dictionary<string, string>> Monthlydatalist;
        private List<MonthlyWorkCodeTime> PresentMonthlyWorkCodeTime;

        public AnalizeViewModel(Control control)
        {
            mycontrol = control;
            Monthlydatalist = new ObservableCollection<Dictionary<string, string>>();
            PresentMonthlyWorkCodeTime = new List<MonthlyWorkCodeTime>();
            LoadWorkDataList();
            LoadMonthlyData();
            LoadGraphData();
        }

        private void LoadWorkDataList()
        {
            var nonOrderdList = new ObservableCollection<WorkItem>();
            foreach(var item in mycontrol.WorkDataList.itemList)
            {
                nonOrderdList.Add(item);
            }
            workdatalist = new ObservableCollection<WorkItem>(nonOrderdList.OrderByDescending(n=>n.StartTime));
        }

        private void LoadMonthlyData()
        {

            DateTime present = DateTime.Now;
            var itemlist = mycontrol.MonthlyWorkCodeTimes.Where(x => x.Year == present.Year & x.Month == present.Month);
            PresentMonthlyWorkCodeTime.AddRange(itemlist.OrderByDescending(x => x.WorkTime));
            foreach (var item in PresentMonthlyWorkCodeTime)
            {
                string minutes = item.WorkTime.Minutes.ToString();
                if (minutes.Length == 1) minutes = '0' + minutes;
                string hours = (item.WorkTime.Days * 24 + item.WorkTime.Hours).ToString();
                string time = hours + ":" + minutes;
                Monthlydatalist.Add(new Dictionary<string, string>(){ { item.WorkCode, time } });
            }

            //できたらバインド
        }
        public void LoadGraphData()
        {
            _PlotModel = new PlotModel() { Title = "開発コードごとの工数" };

            var series = new OxyPlot.Series.PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.5,
                AngleSpan = 360,
                StartAngle = 270,
            };
            DateTime present = DateTime.Now;

            if(PresentMonthlyWorkCodeTime.Any())
            {
                foreach(var item in PresentMonthlyWorkCodeTime)
                {
                    series.Slices.Add(new PieSlice(item.WorkCode,item.WorkTime.TotalMinutes));
                }
            }
            else
            {
                series.Slices.Add(new PieSlice("No Data",100));
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
        public ObservableCollection<Dictionary<string,string>> MonthlyWorkData
        {
            get
            {
                return Monthlydatalist;
            }
        }
        public string PresentMonth
        {
            get
            {
                return DateTime.Now.ToString("yyyy/MM");
            }
        }



        public List<DataPoint> Datalist { get; set; }
        public PlotModel _PlotModel { get; private set; }
        public TimeSpan TotalTime { get; set; }
    }
}
