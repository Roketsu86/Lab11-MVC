using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            List<Wine> wines = new List<Wine>();
            string path = "../../DontWineAboutIt/DontWineAboutIt/wwwroot/Assets/wine.csv";

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<Wine>();
                foreach (var record in records)
                {
                    wines.Add(record);
                }
            }

            return wines;
        }
    }
}
