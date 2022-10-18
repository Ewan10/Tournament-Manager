using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        public static IDataConnection Connections { get; private set; } 

        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connections = sql;
            }

          else if (db == DatabaseType.TextFile)
          {
                TextConnector text = new TextConnector();
                Connections = text;
          }
        }

        public static string CnnString(string name)
        {
            return ConficurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}