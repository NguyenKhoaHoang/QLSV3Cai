using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Câu1
{
    public class SinhVienBangHai:SinhVien
    {
        public string Bang1 { get; set; }
        public string DonViCongTac { get; set; }
        public SinhVienBangHai() { }
        public override string LoaiHinh()
        {
            return NH.SVBH;
        }
    }
}
