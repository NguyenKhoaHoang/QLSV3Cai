using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Câu1
{
    public class CSDL
    {
        public DataTable DSSV { get; set; }
        private static CSDL _instance;
        public static CSDL Instance
        {
            get
            {
                if (_instance == null) _instance = new CSDL();
                return _instance;
            }
            private set { }
        }
        private CSDL()
        {
            DSSV = new DataTable();
            DSSV.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("MSSV", typeof(int)),
                    new DataColumn("HovaTen", typeof(string)),
                    new DataColumn("NgaySinh", typeof(DateTime)),
                    new DataColumn("DiaChi", typeof(string)),
                    new DataColumn("SDT", typeof(string)),
                    new DataColumn("NienKhoa", typeof(int)),
                    new DataColumn("ChuyenNganh",typeof(string)),
                    new DataColumn("Bang1",typeof(string)),
                    new DataColumn("DonViCongTac",typeof(string)),
                });
            DSSV.Rows.Add(new object[]
            {
                101,"NVA",new DateTime(2001,3,4),"DaNang","123212",2019,null,"kinhte","fpt"
            });
            DSSV.Rows.Add(new object[]
            {
                102,"NVB",new DateTime(2001,7,14),"Hue","123457",2019,null,"bacsi","benhvien"
            });
            DSSV.Rows.Add(new object[]
            {
                103,"NVC",new DateTime(2001,12,2),"DaNang","123212",2019,NH.CNPM,null,null
            });
            DSSV.Rows.Add(new object[]
            {
                104,"NVD",new DateTime(2001,1,3),"QuangNam","11282",2019,NH.HTTT,null,null
            });
            DSSV.Rows.Add(new object[]
            {
                105,"NVD",new DateTime(2001,1,3),"DakLak","13212312",2019,NH.MMT,null,null
            });
            DSSV.Rows.Add(new object[]
            {
                106,"NVE",new DateTime(2002,3,15),"CaMau","1456478",2020,null,null,null
            });
            DSSV.Rows.Add(new object[]
            {
                107,"NVF",new DateTime(2002,8,4),"QuangNam","147899",2020,null,null,null
            });
        }
        public void AddDataRowSV(SinhVien s)
        {

        }
        public void EditDataRowSV(SinhVien s)
        {
            foreach(DataRow i in DSSV.Rows)
            {
                if (Convert.ToInt32(i["MSSV"]) == s.MSSV)
                {
                    if (s.LoaiHinh() == NH.SVDH)
                    {
                        i["ChuyenNganh"] = ((SinhVienDaiHoc)s).ChuyenNganh;
                        i["Bang1"] = null;
                        i["DonViCongTac"] = null;
                    }
                    else if(s.LoaiHinh() == NH.SVBH)
                    {
                        i["Bang1"] = ((SinhVienBangHai)s).Bang1;
                        i["DonViCongTac"]= ((SinhVienBangHai)s).DonViCongTac;
                        i["ChuyenNganh"] = null;
                    }
                    else
                    {
                        i["ChuyenNganh"] = null;
                        i["Bang1"] = null;
                        i["DonViCongTac"] = null;
                    }
                    i["MSSV"] = s.MSSV;
                    i["HovaTen"] = s.HovaTen;
                    i["NgaySinh"] = s.NgaySinh;
                    i["DiaChi"] = s.DiaChi;
                    i["SDT"] = s.SDT;
                    i["NienKhoa"] = s.NienKhoa;
                }
            }
        }
        public void DeleteDataRowSV(int MSSV)
        {
            int index = -1;
            foreach (DataRow i in DSSV.Rows)
            {
                if (Convert.ToInt32(i["MSSV"]) == MSSV)
                {
                    index = DSSV.Rows.IndexOf(i);
                }
            }
            DSSV.Rows.RemoveAt(index);
        }

    }
}
