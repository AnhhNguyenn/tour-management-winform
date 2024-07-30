using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class LoaiKS_BLL
    {
        LoaiKS_DAL dalLKS;
        public LoaiKS_BLL()
        {
            dalLKS = new LoaiKS_DAL();
        }

        public DataTable GetAllLoaiKhachSan()
        {
            return dalLKS.GetAllLoaiKhachSan();
        }

        public bool InsertLoaiKhachSan(tbl_LoaiKS lks)
        {
            return dalLKS.InsertLoaiKhachSan(lks);
        }
        public bool UpdateLoaiKhachSan(tbl_LoaiKS lks)
        {
            return dalLKS.UpdateLoaiKhachSan(lks);
        }
        public bool DeleteLoaiKhachSan(tbl_LoaiKS lks)
        {
            return dalLKS.DeleteLoaiKhachSan(lks);
        }
    }
}
