using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC71.Context
{
    public class MyContext
    {
        public static string GetConnection()
        {
            return "Data Source=LAPTOP-IQE37H9B\\MSSQLSERVER01;Initial catalog=Link_VS_to_SSMS;User ID=MCC71;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
