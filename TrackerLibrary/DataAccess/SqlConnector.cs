using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public class SqlConnector : IDataConnection
    {
        public Prize CreatePrize(Prize prize)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Conficuration.CnnString("Tournaments")))
            {
                var parameter = new DynamicParameters();
                parameter.Add("@PlaceNumber", prize.PlaceNumber);
                parameter.Add("@PlaceName", prize.PlaceName);
                parameter.Add("@PrizeAmount", prize.PrizeAmount);
                parameter.Add("@PrizePercentage", prize.PrizePercentage);
                parameter.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);                

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedures);

                prize.Id = parameter.Get<int>("@id");

            }
        }
    }
}