using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class TTTV_BLL
    {
        TTTV_DAL dalTTTV;
        public TTTV_BLL()
        {
            dalTTTV = new TTTV_DAL();
        }

        public bool InsertTTTV(tbl_TTTV tttv)
        {
            return dalTTTV.InsertTTTV(tttv);
        }

        public int GeTSoTVDangCo()
        {
            return dalTTTV.GeTSoTVDangCo();
        }

        public DataTable GetTTTV(tbl_TTTV tttv)
        {
            return dalTTTV.GetTTTV(tttv);
        }

        public bool UpdateTTTV(tbl_TTTV tttv)
        {
            return dalTTTV.UpdateTTTV(tttv);
        }

        public bool DeleteTTTV(tbl_TTTV tttv)
        {
            return dalTTTV.DeleteTTTV(tttv);
        }

        public DataTable GetTTTV2(tbl_HoaDon hoadon)
        {
            return dalTTTV.GetTTTV2(hoadon);
        }

    }
}
