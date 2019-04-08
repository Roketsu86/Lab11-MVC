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
        public string Province { get; set; }
        public string Region_1 { get; set; }
        public string Region_2 { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }


        public static List<Wine> GetWineList()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../wwwroot/wine.csv");
            var lines = File.ReadLines(path).Skip(1).Take(100);
            List<Wine> wineList = new List<Wine>();
            int points = 0;
            decimal price = 0m;


            foreach (string line in lines)
            {
                string[] wineInfo = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                Wine wine = new Wine
                {
                    ID = int.Parse(wineInfo[0]),
                    Country = wineInfo[1],
                    Description = wineInfo[2],
                    Designation = wineInfo[3],
                    Points = Int32.TryParse(wineInfo[4], out points) ? points : -1,
                    Price = Decimal.TryParse(wineInfo[5], out price) ? price : 99999999.99m,
                    Province = wineInfo[6],
                    Region_1 = wineInfo[7],
                    Region_2 = wineInfo[8],
                    Variety = wineInfo[9],
                    Winery = wineInfo[10]
                };

                wineList.Add(wine);
            }

            return wineList;
        }
    }
}
