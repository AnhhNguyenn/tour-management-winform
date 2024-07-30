using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class PhuongTien_BLL
    {
        PhuongTien_DAL dalPhuongTien;
        public PhuongTien_BLL()
        {
            dalPhuongTien = new PhuongTien_DAL();
        }

        public DataTable GetAllPhuongTien()
        {
            return dalPhuongTien.GetAllPhuongTien();
        }

        public bool InsertPhuongTien(tbl_PhuongTien pt)
        {
            return dalPhuongTien.InsertPhuongTien(pt);
        }
        public bool UpdatePhuongTien(tbl_PhuongTien pt)
        {
            return dalPhuongTien.UpdatePhuongTien(pt);
        }
        public bool DeletePhuongTien(tbl_PhuongTien pt)
        {
            return dalPhuongTien.DeletePhuongTien(pt);
        }
    }
}

