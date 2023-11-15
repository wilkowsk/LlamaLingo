using System;
using System.Collections.Generic;

namespace LlamaLingo.Pages
{
    public partial class ToastFeatures
    {
        public class ChartDataModel
        {
            public string Month { get; set; }
            public double Temperature { get; set; }
        }

        public static List<ChartDataModel> ChartData = new List<ChartDataModel>
        {
            new ChartDataModel
            {
                Month = "Jan",
                Temperature = 1
            },
            new ChartDataModel
            {
                Month = "Jun",
                Temperature = 21
            },
            new ChartDataModel
            {
                Month = "Jul",
                Temperature = 12
            }
        };
        public static List<string> Names = new List<string>
        {
            "Test",
            "Test2",
            "Test3"
        };
        public void Update()
        {
            Random rand = new Random();
            //string output;
            List<int> myList = SyncfusionBlazorAppDemo.Pages.MySqlQuery.getData();
            for (int i = 0; i < myList.Count; i++)
            {
                ChartData.Add(new ChartDataModel { Month = Names[i], Temperature = myList[i] });
                ChartData.Remove(ChartData[0]);
            }
        /*
		ChartData.Clear();
		for (int i = 0; i < ChartData.Count; i++)
		{
			ChartDataModel model = new ChartDataModel { Month = "Jan", Temperature = 4 };
			ChartData.Add(model);
		}
		*/
        }
    }
}