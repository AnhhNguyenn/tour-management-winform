using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class LLT_BLL
    {
        LLT_DAL dalLLT;
        public LLT_BLL()
        {
            dalLLT = new LLT_DAL();
        }

        public DataTable GetAllLLT()
        {
            return dalLLT.GetAllLLT();
        }

        public bool InsertLoaiLuaTuoi(tbl_LoaiLT llt)
        {
            return dalLLT.InsertLoaiLuaTuoi(llt);
        }
        public bool UpdateLoaiLuaTuoi(tbl_LoaiLT llt)
        {
            return dalLLT.UpdateLoaiLuaTuoi(llt);
        }
        public bool DeleteLoaiLuaTuoi(tbl_LoaiLT llt)
        {
            return dalLLT.DeleteLoaiLuaTuoi(llt);
        }

    }
}
