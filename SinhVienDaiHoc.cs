using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Câu1
{
    public class SinhVienDaiHoc : SinhVien
    {
        public string ChuyenNganh { get; set; }
        public SinhVienDaiHoc() { }
        public override string LoaiHinh()
        {
            return NH.SVDH;
        }
    }
}
    