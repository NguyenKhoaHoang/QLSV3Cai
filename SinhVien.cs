using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Câu1
{
    public abstract class SinhVien
    {
        public int MSSV { get; set; }
        public string HovaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public int NienKhoa { get; set; }
        public abstract string LoaiHinh();
    }
}
