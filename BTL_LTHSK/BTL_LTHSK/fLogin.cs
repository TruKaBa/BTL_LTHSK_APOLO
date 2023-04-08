using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BTL_LTHSK
{
    public partial class fLogin : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        private string procCheckAccount = "Proc_KiemTraDangNhap";

        public fLogin()
        {
            InitializeComponent();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = procCheckAccount;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@username", tbUserName.Text);
                        command.Parameters.AddWithValue("@password", tbPassword.Text);

                        connection.Open();
                        var result = command.ExecuteScalar();
                        connection.Close();

                        if (result == null)
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu sai", "Thông báo");
                            clearTextBox();

                        } else
                        {
                            clearTextBox();
                            fMain fMain = new fMain();
                            this.Hide();
                            fMain.ShowDialog();
                            this.Show();
                            tbUserName.Focus();
                        }

                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void clearTextBox()
        {
            tbUserName.Text = String.Empty;
            tbPassword.Text = String.Empty;
        }
    }
}
