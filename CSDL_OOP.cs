using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Câu1
{
    public class CSDL_OOP
    {
        private static CSDL_OOP _instance;

        public static CSDL_OOP Instance
        {
            get
            {
                if (_instance == null) _instance = new CSDL_OOP();
                return _instance;
            }
            private set { }
        }
        private CSDL_OOP() { }
        public SinhVien GetSV(DataRow i)
        {
            SinhVien s = null;
            string CN = i["ChuyenNganh"].ToString();
            string B1 = i["Bang1"].ToString();
            string DVCT = i["DonViCongTac"].ToString();
            if (CN != "")
            {
                s = new SinhVienDaiHoc()
                {
                    ChuyenNganh = CN
                };
            }
            else if (B1 != "" || DVCT != "")
            {
                s = new SinhVienBangHai()
                {
                    Bang1 = B1,
                    DonViCongTac = DVCT
                };
            }
            else
            {
                s = new SinhVienCaoDang() { };
            }
            s.MSSV = Convert.ToInt32(i["MSSV"].ToString());
            s.HovaTen = i["HovaTen"].ToString();
            s.NgaySinh = Convert.ToDateTime(i["NgaySinh"].ToString());
            s.DiaChi = i["DiaChi"].ToString();
            s.SDT = i["SDT"].ToString();
            s.NienKhoa = Convert.ToInt32(i["NienKhoa"].ToString());
            return s;
        }
        public List<SinhVien> GetAllSV()
        {
            List<SinhVien> list = new List<SinhVien>();
            DataTable dt = CSDL.Instance.DSSV;
            foreach(DataRow i in dt.Rows)
            {
                list.Add(GetSV(i));
            }
            return list;
        }
        public SinhVien GetSVByMSSV(int MSSV)
        {
            List<SinhVien> list = GetAllSV();
            foreach (SinhVien i in list)
            {
                if (i.MSSV == MSSV) return i;
            }
            return null;
        }
        public void ExcuteDB(SinhVien s)
        {
            bool check = false;
            foreach (SinhVien i in GetAllSV())
            {
                if (s.MSSV == i.MSSV)
                    check = true;
            }
            if (check)
            {
                CSDL.Instance.EditDataRowSV(s);
            }
            else
                CSDL.Instance.AddDataRowSV(s);
        }
        public void DeleteSV(int MSSV)
        {
            CSDL.Instance.DeleteDataRowSV(MSSV);
        }
    }
}
