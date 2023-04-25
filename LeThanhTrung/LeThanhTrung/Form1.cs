using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeThanhTrung
{
    public partial class Form1 : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTinhDiem_Click(object sender, EventArgs e)
        {
            string ten = tbTen.Text;
            string lop = cbLopHc.Text;
            float diemcc = float.Parse(tbDiemCC.Text);
            float diemgk = float.Parse(tbDiemGk.Text);
            float diemck = float.Parse(tbDiemCuoiKy.Text);
            float diem = (diemcc + diemgk + diemck) / 3;

            rtbKetQua.Text = "Họ và tên: " +ten+  "\nLớp hành chính: " +lop+ "\nĐiểm: "+diem;
            
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            tbTen.Text = String.Empty;
            cbMonHoc.ResetText();
            cbLopHc.ResetText();
            tbDiemCC.Text = String.Empty;
            tbDiemGk.Text = String.Empty;
            tbDiemCuoiKy.Text = String.Empty;
            rtbKetQua.Text = String.Empty;
            tbTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbDiemCC_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbDiemGk_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDiemCuoiKy_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDiemCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbDiemGk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbDiemCuoiKy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
