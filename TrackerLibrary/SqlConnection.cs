using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class SqlConnection: IDataConnection {

        public Prize CreatePrize(Prize prize)
        {
            prize.Id = 1;

            return prize;
        }
    }
}