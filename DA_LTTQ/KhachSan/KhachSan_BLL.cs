using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class KhachSan_BLL
    {
        KhachSan_DAL dalKS;
        public KhachSan_BLL()
        {
            dalKS = new KhachSan_DAL();
        }

        public DataTable GetAllKhachSan()
        {
            return dalKS.GetAllKhachSan();
        }

        public bool InsertKhachSan(tbl_KhachSan ks)
        {
            return dalKS.InsertKhachSan(ks);
        }
        public bool UpdateKhachSan(tbl_KhachSan ks)
        {
            return dalKS.UpdateKhachSan(ks);
        }
        public bool DeleteKhachSan(tbl_KhachSan ks)
        {
            return dalKS.DeleteKhachSan(ks);
        }
    }
}
