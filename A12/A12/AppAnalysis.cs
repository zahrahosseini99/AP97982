using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;
namespace A12
{
    public class AppAnalysis
    {
        public List<AppData> Apps;
        public AppAnalysis()
        {
            this.Apps = new List<AppData>();
        }

        public static AppAnalysis AppAnalysisFactory(string appDataPath)
        {
            List<AppData> Apps = new List<AppData>();
            var appAnalysis = new AppAnalysis();
            using (TextFieldParser parser = new TextFieldParser(appDataPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                var fields = parser.ReadFields();
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    appAnalysis.AppendApp(fields);
                }
            }
            return appAnalysis;
        }

        private void AppendApp(string[] fields)
        {
            AppData app = new AppData(fields);
            Apps.Add(app);
        }

        public long AllAppsCount()
        {
            return Apps.Count();
        }
        public long AppsAboveXRatingCount(double x)
        {
            return Apps.Where(i => i.Rating >= x).Count();
        }

        public long RecentlyUpdatedCount(DateTime boundary)
        {
            return Apps.Where(i => i.LastUpdate >= boundary).Count();
        }
        public string RecentlyUpdatedFreqCat(DateTime boundary)
        {
            return Apps.Where(x => x.LastUpdate >= boundary).GroupBy(x => x.Category)
                    .OrderByDescending(grp => grp.Count())
            .Select(grp => grp.Key).First();
        }
        public List<string> MostRatedCategories(double ratingBoundary, int n)
        {
            return Apps.Where(x => x.Rating > ratingBoundary).GroupBy(x => x.Category)
                           .OrderByDescending(g => g.Count()).Select(g => g.Key).Take(n).ToList();
        }
        public double TopQuarterBoundary()
        {

            int n = Apps.Where(i => i.Category == "PHOTOGRAPHY").Count();
            return Apps.Where(i => i.Category == "PHOTOGRAPHY")
                .OrderBy(d => d.Rating).Select(d => d.Rating).Take(3 * n / 4).Last();
        }
        public Tuple<string, string> ExtremeMeanUpdateElapse(DateTime today)
        {
            string first, last = null;
            first = Apps.GroupBy(a => a.Category).OrderBy(a => a.Average(i => (today - i.LastUpdate).TotalDays))
                 .Select(i => i.Key).First();
            last = Apps.GroupBy(a => a.Category).OrderBy(a => a.Average(i => (today - i.LastUpdate).TotalDays))
               .Select(i => i.Key).Last();
            Tuple<string, string> res = new Tuple<string, string>(first, last);
            return res;
        }
        public List<string> XMostProfitables(int x)
        {
            return Apps.OrderByDescending(i => i.Price * i.Installs).Take(x).Select(a => a.Name).ToList();
        }
        public List<string> XCoolestApps(int x, Func<AppData, double> criteria)
        {
            criteria = (app) => app.Rating * app.Installs / 1000;
            return Apps.OrderBy(i => criteria(i)).Take(x).Select(i => i.Name).ToList();
        }
    }
}