using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextServices;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeModels.csv";

        public Prize CreatePrize(Prize prize)
        {
            List<Prize> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizes();

            int currentId = 1;

            if (prizes.Count > 0) 
            {
                int currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }
            
            prize.Id = currentId;

            prizes.Add(prize);

            prizes.SaveToPrizeFile(PrizeFile);

            return prize;
        }
    }
}