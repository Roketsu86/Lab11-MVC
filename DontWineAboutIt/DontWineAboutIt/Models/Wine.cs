using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DontWineAboutIt.Models
{
    public class Wine
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
        public int Points { get; set; }
        public decimal Price { get; set; }
        public string Region_1 { get; set; }
        public string Region_2 { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }


        public static List<Wine> GetWineList()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../wwwroot/wine.csv");
            var lines = File.ReadLines(path).Take(100);
            Regex parser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            List<Wine> wineList = new List<Wine>();

            foreach (string line in lines)
            {
                string[] wineInfo = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                Wine wine = new Wine
                {
                    ID = int.Parse(wineInfo[0]),
                    Country = wineInfo[1],
                    Description = wineInfo[2],
                    Designation = wineInfo[3],
                    Points = int.Parse(wineInfo[4]),
                    Price = decimal.Parse(wineInfo[5]),
                    Region_1 = wineInfo[6],
                    Region_2 = wineInfo[7],
                    Variety = wineInfo[8],
                    Winery = wineInfo[9]
                };

                wineList.Add(wine);
            }

            return wineList;
        }
    }
}
