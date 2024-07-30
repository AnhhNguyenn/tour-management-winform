using System;
using System.Data;
using System.Data.SqlClient;

namespace DA_LTTQ
{
    class Tour_DAL
    {
        DataConnection dataCon;
        SqlDataAdapter sqlDA;
        SqlCommand cmd;

        public Tour_DAL()
        {
            dataCon = new DataConnection();
        }

        public DataTable GetTourBanChay()
        {
            string sql = "select * from tour where matour = (select top 1 matour from test2 where tongtv = (select max(tongtv) from test2))";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable GetAllTour2(tbl_Tour tour)
        {
            string sql = "SELECT * FROM TOUR WHERE MATOUR = '" + tour.MaTour + "'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable GetLocTour(tbl_Tour tour)
        {
            string sql = "SELECT MATOUR, TENTOUR, SOLUONGCONLAI, NGAYDITOUR, NGAYKETTHUC, GIATOUR FROM dbo.TOUR WHERE MALTOUR = '" + tour.MaLTour + "'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }


        public bool UpdatesltOUR(tbl_Tour tour, tbl_KhachHang khachhang)
        {
            string sql = "update tour set soluongconlai = soluongconlai - (select count(matv) from thongtintv where makh = '" + khachhang.MaKH + "') where matour = '" + tour.MaTour + "'";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //public DataTable GetTourNgoaiNc(tbl_Tour tour)
        //{
        //    string sql = "SELECT * FROM TOUR WHERE MATOUR = '" + tour.MaTour + "'";
        //    SqlConnection con = dataCon.getConnect();
        //    sqlDA = new SqlDataAdapter(sql, con);
        //    con.Open();
        //    DataTable dataTable = new DataTable();
        //    sqlDA.Fill(dataTable);
        //    con.Close();
        //    return dataTable;
        //}

        public DataTable LocTour(tbl_Tour tour)
        {
            string sql = "EXEC SP_LocTour @MaLTour = '" + tour.MaLTour + "', @MaDDi = '" + tour.MaDDi + "', @MaDDen = '" + tour.MaDDen + "', @SoNgay1 = " + tour.SoNgay1 + ", @SoNgay2 = " + tour.SoNgay2 + ", @NgayDi = '" + tour.NgayDiTour.ToString("yyyy-MM-dd") + "', @SoNguoi = " + tour.SLLoc + ", @MaPT = '" + tour.MaPT + "'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable SearchTour(tbl_Tour tour)
        {
            string sql = "SELECT MATOUR, TENTOUR, SOLUONGCONLAI, NGAYDITOUR, NGAYKETTHUC, GIATOUR FROM dbo.TOUR WHERE MATOUR LIKE '%" + tour.MaTour + "%' OR TENTOUR LIKE N'%" + tour.TenTour + "%'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public DataTable GetTTTour(tbl_Tour tour)
        {
            string sql = "EXEC dbo.SP_GetTTTour @MaTour = '" + tour.MaTour + "'";
            SqlConnection con = dataCon.getConnect();
            sqlDA = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dataTable = new DataTable();
            sqlDA.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        public byte[] GetPhoto(tbl_Tour tour)
        {
            string sql = "SELECT ANH1 FROM TOUR WHERE MATOUR = '" + tour.MaTour + "'";
            SqlConnection con = dataCon.getConnect();
            SqlDataReader reader;
            con.Open();
            cmd = new SqlCommand(sql, con);
            reader = cmd.ExecuteReader();
            byte[] img;
            reader.Read();
            img = ((byte[])reader[0]);
            con.Close();
            return img;
        }

        public bool InsertTour(tbl_Tour tour)
        {
            string sql = "INSERT INTO TOUR(MATOUR, TENTOUR, MOTA, SOLUONGCONLAI, NGAYDITOUR, NGAYKETTHUC, ANH1, ANH2, ANH3, ANH4, GIATOUR, MALTOUR, MAPT, MADDI, MADDEN, MALKS) VALUES(@MATOUR, @TENTOUR, @MOTA, @SOLUONGCONLAI, @NGAYDITOUR, @NGAYKETTHUC, @ANH1, @ANH2, @ANH3, @ANH4, @GIATOUR, @MALTOUR, @MAPT, @MADDI, @MADDEN, @MALKS)";
            SqlConnection con = dataCon.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MATOUR", SqlDbType.VarChar).Value = tour.MaTour;
                cmd.Parameters.Add("@TENTOUR", SqlDbType.NVarChar).Value = tour.TenTour;
                cmd.Parameters.Add("@MOTA", SqlDbType.NVarChar).Value = tour.MoTa;
                cmd.Parameters.Add("@SOLUONGCONLAI", SqlDbType.Int).Value = tour.SoLuongConLai;
                cmd.Parameters.Add("@NGAYDITOUR", SqlDbType.Date).Value = tour.NgayDiTour.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@NGAYKETTHUC", SqlDbType.Date).Value = tour.NgayKetThuc.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("ANH1", tour.Anh1);
                cmd.Parameters.AddWithValue("ANH2", tour.Anh2);
                cmd.Parameters.AddWithValue("ANH3", tour.Anh3);
                cmd.Parameters.AddWithValue("ANH4", tour.Anh4);
                cmd.Parameters.Add("@GIATOUR", SqlDbType.Decimal).Value = tour.GiaTour;
                cmd.Parameters.Add("@MALTOUR", SqlDbType.VarChar).Value = tour.MaLTour;
                cmd.Parameters.Add("@MAPT", SqlDbType.VarChar).Value = tour.MaPT;
                cmd.Parameters.Add("@MADDI", SqlDbType.VarChar).Value = tour.MaDDi;
                cmd.Parameters.Add("@MADDEN", SqlDbType.VarChar).Value = tour.MaDDen;
                cmd.Parameters.Add("@MALKS", SqlDbType.VarChar).Value = tour.MaLKS;
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(tbl_Tour tour)
        {
            string sql = "UPDATE TOUR SET TENTOUR = @TENTOUR, MOTA = @MOTA, SOLUONGCONLAI = @SOLUONGCONLAI, NGAYDITOUR = @NGAYDITOUR, NGAYKETTHUC = @NGAYKETTHUC, ANH1 = @ANH1, ANH2 = @ANH2, ANH3 = @ANH3, ANH4 = @ANH4, GIATOUR = @GIATOUR, MALTOUR = @MALTOUR, MAPT = @MAPT, MADDI = @MADDI, MADDEN = @MADDEN, MALKS = @MALKS WHERE MATOUR = @MATOUR";
            SqlConnection con = dataCon.getConnect();

            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MATOUR", SqlDbType.VarChar).Value = tour.MaTour;
                cmd.Parameters.Add("@TENTOUR", SqlDbType.NVarChar).Value = tour.TenTour;
                cmd.Parameters.Add("@MOTA", SqlDbType.NVarChar).Value = tour.MoTa;
                cmd.Parameters.Add("@SOLUONGCONLAI", SqlDbType.Int).Value = tour.SoLuongConLai;
                cmd.Parameters.Add("@NGAYDITOUR", SqlDbType.Date).Value = tour.NgayDiTour.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@NGAYKETTHUC", SqlDbType.Date).Value = tour.NgayKetThuc.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("ANH1", tour.Anh1);
                cmd.Parameters.AddWithValue("ANH2", tour.Anh2);
                cmd.Parameters.AddWithValue("ANH3", tour.Anh3);
                cmd.Parameters.AddWithValue("ANH4", tour.Anh4);
                cmd.Parameters.Add("@GIATOUR", SqlDbType.Decimal).Value = tour.GiaTour;
                cmd.Parameters.Add("@MALTOUR", SqlDbType.VarChar).Value = tour.MaLTour;
                cmd.Parameters.Add("@MAPT", SqlDbType.VarChar).Value = tour.MaPT;
                cmd.Parameters.Add("@MADDI", SqlDbType.VarChar).Value = tour.MaDDi;
                cmd.Parameters.Add("@MADDEN", SqlDbType.VarChar).Value = tour.MaDDen;
                cmd.Parameters.Add("@MALKS", SqlDbType.VarChar).Value = tour.MaLKS;
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool DeleteTour(tbl_Tour tour)
        {
            string sql = "DELETE TOUR WHERE MATOUR = @MATOUR";
            SqlConnection con = dataCon.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MATOUR", SqlDbType.VarChar).Value = tour.MaTour;
                cmd.ExecuteNonQuery();
                con.Close();
            }

            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public int GetMaTour()
        {
            string sql = "SELECT COUNT(MaTour) +1 FROM TOUR";
            SqlConnection con = dataCon.getConnect();

            cmd = new SqlCommand(sql, con);
            con.Open();
            int IDTOUR = (int)cmd.ExecuteScalar();
            con.Close();

            return IDTOUR;
        }
    }
}
