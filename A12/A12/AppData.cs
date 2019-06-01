using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;


namespace A12
{
    public class AppData
    {
        public string Name;
        public string Categori;
        public double Rating;
        public long Reviews;
        public double size;
        public long Installs;
        public string IsFree;
        public double Price;
        public string ContentRating;
        public string Genres;
        public DateTime LastUpdate;
        public string CurrentVersion;
        public string AndroidVersion;
        public AppData(string[] fields)
        {
            Name = fields[0];
            Categori = fields[1];
            Rating = double.Parse(fields[2]);
            Reviews = long.Parse(fields[3]);
            if (fields[4] == "Varies with device")
            {
                fields[4] = "0";
                size = double.Parse(fields[4].TrimEnd('M'));
            }
            else
                size = double.Parse(fields[4].TrimEnd('M', 'k'));
            Installs = int.Parse(fields[5].TrimStart('"').TrimEnd('"').TrimEnd('+'), NumberStyles.AllowThousands);
            IsFree = fields[6];
            Price = double.Parse(fields[7].TrimStart('$'));
            ContentRating = fields[8];
            Genres = fields[9];
            LastUpdate = DateTime.Parse(fields[10]);
            if (fields[11] == "Varies with device")
            {
                fields[11] = "0";
                CurrentVersion = fields[11];
            }
            else
                CurrentVersion = fields[11];
            if (fields[12] == "Varies with device")
            {
                fields[12] = "0";
                AndroidVersion = fields[12];
            }
            else
                AndroidVersion = fields[12];

        }
    }
}