
using System.Data;
using System.Data.SqlClient;

namespace DA_LTTQ
{
    class LoaiTour_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public LoaiTour_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetAllLTour()
        {
            string sql = "SELECT * FROM LOAITOUR";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }
    }
}
