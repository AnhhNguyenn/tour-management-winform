using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class DiemDi_BLL
    {
        DiemDi_DAL dalDiemDi;
        public DiemDi_BLL()
        {
            dalDiemDi = new DiemDi_DAL();
        }

        public DataTable GetAllDDiTrongNc()
        {
            return dalDiemDi.GetAllDDiTrongNc();
        }

        public DataTable GetAllDDi(tbl_DiemDi ddi)
        {
            return dalDiemDi.GetAllDDi(ddi);
        }

        //public DataTable GetAllDDiNgoaiNc()
        //{
        //    return dalDiemDi.GetAllDDiNgoaiNc();
        //}

        public bool InsertDDi(tbl_DiemDi dd)
        {
            return dalDiemDi.InsertDDi(dd);
        }

        public bool UpdateDDi(tbl_DiemDi dd)
        {
            return dalDiemDi.UpdateDDi(dd);
        }

        public bool DeleteDDi(tbl_DiemDi dd)
        {
            return dalDiemDi.DeleteDDi(dd);
        }
    }
}
