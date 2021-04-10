using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Câu1
{
    public class SinhVienCaoDang : SinhVien
    {
        public SinhVienCaoDang() { }
        public override string LoaiHinh()
        {
            return NH.SVCD;
        }
    }
}
