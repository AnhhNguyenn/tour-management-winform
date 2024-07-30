using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DA_LTTQ
{
    class tbl_Tour
    {
        public string MaTour { get; set; }

        public string TenTour { get; set; }

        public string MoTa { get; set; }

        public int SLLoc { get; set; }

        public int SoNgay1 { get; set; }

        public int SoNgay2 { get; set; }

        public int SoLuongConLai { get; set; }

        public DateTime NgayDiTour { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public byte[] Anh1 { set; get; }

        public byte[] Anh2 { set; get; }

        public byte[] Anh3 { set; get; }

        public byte[] Anh4 { set; get; }

        public decimal GiaTour { get; set; }

        public string MaLTour { get; set; }

        public string MaPT { get; set; }
        
        public string MaDDi { get; set; }

        public string MaDDen { get; set; }

        public string MaLKS { get; set; }
    }
}
