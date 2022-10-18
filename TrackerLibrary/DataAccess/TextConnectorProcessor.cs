using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.DataAccess.TextServices
{
    public static class TextConnectorProcessor
    {
        public static string FullFilePath(this string filename)
        {
            return $"{ ConfigurationManager.AppSettings["filePatch"]}\\{fileName }";
        }

        public static List<string> LoadFile(this string file)
        {
            if (File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<Prize> ConvertToPrizes(this List<string> lines)
        {
            List<Prize> output = new List<Prize>();

            foreach (string line in lines)
            {
                string[] columns = line.split(',');

                Prize prize = new Prize();
                prize.Id = int.Parse(columns[0]);
                prize.PlaceNumber = int.Parse(columns[1]);
                prize.PlaceName = columns[2];
                prize.PrizeAmount = decimal.Parse(columns[3]);
                prize.PrizePercentage = double.Parse(columns[4]);
                output.Add(prize);
            }

            return output;
        }

        public static void SaveToPrizeFile(this List<PrizeModel> prizes, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (Prize prize in prizes)
            {
                lines.Add($"{prize.Id "}, {prize.PlaceNumber },{ prize.PlaceName },{ prize.PrizeAmount }, { prize.PrizePercentage }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }
    }
}