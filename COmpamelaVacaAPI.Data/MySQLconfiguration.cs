using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COmpamelaVacaAPI.Data
{
    public class MySQLconfiguration
    {
        public MySQLconfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }
    }
}
