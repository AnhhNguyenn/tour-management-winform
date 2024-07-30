using System.Data.SqlClient;

namespace DA_LTTQ
{
    class DataConnection
    {
        string conStr;
        public DataConnection()
        {
            conStr = @"Data Source=BUM;Initial Catalog=DA_LTTQ;Integrated Security=True";
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
