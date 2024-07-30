using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class User_DAL
    {
        DataConnection dataCon;
        SqlCommand cmd;

        public User_DAL()
        {
            dataCon = new DataConnection();
        }

        public string PhQuyen(tbl_User user)
        {
            string sql = "SELECT * FROM dbo.[USER] WHERE UserName = '" + user.UserName + "' AND [Password] = '" + user.Password + "'";
            SqlConnection con = dataCon.getConnect();
            SqlDataReader reader;
            con.Open();
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            String Quyen = "";
            reader.Read();
            if (reader.HasRows)
            {

                if (reader[3].ToString() == "Admin")
                    Quyen = "Admin";
            }

            if (reader.HasRows)
            {

                if (reader[3].ToString() == "User")
                    Quyen = "User";
            }

            else
                Quyen = "Fail";

            return Quyen;
        }
    }
}
