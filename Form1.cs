using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Câu1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetCBB();
            show();
        }
        public void show()
        {
            dgvList.DataSource = CSDL_OOP.Instance.GetAllSV();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void GetCBB()
        {
            cbbUni.Items.Clear();
            cbbUni.Items.AddRange(new CBBItems[]
            {
                new CBBItems{Text=NH.CNPM,Value=0},
                new CBBItems{Text=NH.HTTT,Value=1},
                new CBBItems{Text=NH.MMT,Value=2},
                new CBBItems{Text=NH.HTN,Value=3},
            });
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvList.CurrentRow.Cells["MSSV"].Value.ToString();
            txtName.Text = dgvList.CurrentRow.Cells["HoVaTen"].Value.ToString();
            txtAddress.Text = dgvList.CurrentRow.Cells["DiaChi"].Value.ToString();
            dtDate.Value = Convert.ToDateTime(dgvList.CurrentRow.Cells["NgaySinh"].Value.ToString());
            txtPhone.Text = dgvList.CurrentRow.Cells["SDT"].Value.ToString();
            txtYear.Text = dgvList.CurrentRow.Cells["NienKhoa"].Value.ToString();
            SinhVien s = CSDL_OOP.Instance.GetSVByMSSV(Convert.ToInt32(txtId.Text));
            if (s.LoaiHinh() == NH.SVDH)
            {
                txtBang1.Text = "";
                txtCongTac.Text = "";
                rdUni.Checked = true;
                cbbUni.Text = ((SinhVienDaiHoc)s).ChuyenNganh;
            }
            else if (s.LoaiHinh() == NH.SVBH)
            {
                rdBang2.Checked = true;
                cbbUni.Text = "";
                txtBang1.Text = ((SinhVienBangHai)s).Bang1;
                txtCongTac.Text = ((SinhVienBangHai)s).DonViCongTac;
            }
            else if (s.LoaiHinh() == NH.SVCD)
            {
                txtBang1.Text = "";
                txtCongTac.Text = "";
                cbbUni.Text = "";
                rdCol.Checked = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SinhVien s = null;
            if (dgvList.SelectedRows.Count == 1)
            {
                if (rdUni.Checked == true)
                {
                    s = new SinhVienDaiHoc()
                    {
                        ChuyenNganh = ((CBBItems)cbbUni.SelectedItem).Text
                    };
                }
                else if (rdBang2.Checked == true)
                {
                    s = new SinhVienBangHai()
                    {
                        Bang1 = txtBang1.Text,
                        DonViCongTac = txtCongTac.Text
                    };
                }
                else
                {
                    s = new SinhVienCaoDang();
                }
                s.MSSV = Convert.ToInt32(txtId.Text);
                s.HovaTen = txtName.Text;
                s.NgaySinh = dtDate.Value;
                s.DiaChi = txtAddress.Text;
                s.SDT = txtPhone.Text;
                s.NienKhoa = Convert.ToInt32(txtYear.Text);
                CSDL_OOP.Instance.ExcuteDB(s);
            }
            show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dgvList.SelectedRows;
            int[] MSSV = new int[r.Count];
            int index = 0;
            foreach (DataGridViewRow i in r)
            {
                MSSV[index] = Convert.ToInt32(i.Cells["MSSV"].Value);
                CSDL_OOP.Instance.DeleteSV(MSSV[index]);
                index++;
            }
            show();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtBang1.Text = "";
            txtCongTac.Text = "";
            txtPhone.Text = "";
            txtYear.Text = "";
            dtDate.Value = DateTime.Now;
            cbbUni.Text = "";
            rdUni.Checked = true;
        }

        private void rdCol_CheckedChanged(object sender, EventArgs e)
        {
            txtBang1.Text = "";
            txtCongTac.Text = "";
            cbbUni.SelectedIndex = -1;
            if (rdUni.Checked == true)
            {
                cbbUni.SelectedIndex = 0;
            }
        }

        private void rdBang2_CheckedChanged(object sender, EventArgs e)
        {
            txtBang1.Text = "";
            txtCongTac.Text = "";
            cbbUni.SelectedIndex = -1;
            if (rdUni.Checked == true)
            {
                cbbUni.SelectedIndex = 0;
            }
        }

        private void rdUni_CheckedChanged(object sender, EventArgs e)
        {
            txtBang1.Text = "";
            txtCongTac.Text = "";
            cbbUni.SelectedIndex = -1;
            if (rdUni.Checked == true)
            {
                cbbUni.SelectedIndex = 0;
            }
        }
    }
}

