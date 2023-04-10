using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTHSK
{
    public partial class fTeacher : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        private ErrorProvider errorProvider = new ErrorProvider();
        private DataView dataView = new DataView();

        public fTeacher()
        {
            InitializeComponent();
        }

        private void fTeacher_Load(object sender, EventArgs e)
        {
            rdMale.Checked = true;
            toggleDisableButton();
            loadDataToComboBoxDepartment();
            loadDataToGridView();
        }

        private void tbTeacherID_TextChanged(object sender, EventArgs e)
        {
            if (tbTeacherID.Text.Length > 0)
            {
                toggleDisableButton(true, true, true, true, true);
            }
            else
            {
                toggleDisableButton();
            }
        }

        private void toggleDisableButton(bool addButton = false, bool changeButton = false, bool deleteButton = false, bool searchButton = false, bool cancelButton = false)
        {
            btnAdd.Enabled = addButton;
            btnChange.Enabled = changeButton;
            btnDelete.Enabled = deleteButton;
            btnSearch.Enabled = searchButton;
            btnCancel.Enabled = cancelButton;
        }

        private void loadDataToComboBoxDepartment()
        {
            try
            {
                string proc = "selectKhoa";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = proc;
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dtDepartment = new DataTable())
                            {
                                adapter.Fill(dtDepartment);
                                if (dtDepartment.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dtDepartment.Rows)
                                    {
                                        cbDepartment.Items.Add(row["sMaKhoa"]);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Không tồn tại bản ghi nào");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tbTeacherName_TextChanged(object sender, EventArgs e)
        {
            if (hasNumberInName(tbTeacherName.Text)) {
                errorProvider.SetError(tbTeacherName, "Tên không được chứa chữ số");
                toggleDisableButton(cancelButton: true);
                
            } else
            {
                errorProvider.SetError(tbTeacherName, null);
            }
        }

        private bool hasNumberInName(string teacherName)
        {
            bool result = teacherName.Any(char.IsDigit);
            return result;
        }

        private void loadDataToGridView(string filter = "")
        {
            try
            {
                string query = "Proc_SelectAlltblGiangVien";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable table = new DataTable())
                            {
                                adapter.Fill(table);

                                if (table.Rows.Count > 0)
                                {
                                    dataView = table.DefaultView;

                                    dgvTeacher.DataSource = dataView;
                                    dgvTeacher.Columns["sMaGV"].ReadOnly = true;
                                    dgvTeacher.Columns["sTenGV"].ReadOnly = true;
                                    dgvTeacher.Columns["sGioiTinh"].ReadOnly = true;
                                    dgvTeacher.Columns["dNgaySinh"].ReadOnly = true;
                                    dgvTeacher.Columns["sMaKhoa"].ReadOnly = true;

                                    if (!string.IsNullOrEmpty(filter)) dataView.RowFilter = filter;
                                }
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvTeacher.CurrentRow.Index;
            tbTeacherID.Text = dataView[index]["sMaGV"].ToString();
            tbTeacherName.Text = dataView[index]["sTenGV"].ToString();
            if (isMale(dataView[index]["sGioiTinh"].ToString()))
            {
                rdMale.Checked = true;
            } else
            {
                rdFemale.Checked = true;
            }
            DateTime dateOfBirth = formatDateOfBirth(dataView[index]["dNgaySinh"].ToString());
            dtpDateOfBirth.Value = dateOfBirth;
            cbDepartment.Text = dataView[index]["sMaKhoa"].ToString();

            tbTeacherID.ReadOnly = true;
            toggleDisableButton(changeButton: true, deleteButton: true, searchButton: true, cancelButton: true);
        }

        private bool isMale(string gender)
        {
            if (gender == "Nam")
            {
                return true;
            }
            return false;
        }

        private string genderOfTeacher()
        {
            string result = "Nữ";
            if (rdMale.Checked)
            {
                result = "Nam";
                return result;
            }
            return result;
        }

        private DateTime formatDateOfBirth(string dateOfBirth)
        {
            DateTime result = Convert.ToDateTime(dateOfBirth);
            return result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string teacherId = tbTeacherID.Text;
                string gender = genderOfTeacher();
               

                if (!isTeacherIDExist(teacherId))
                {
                    string query = "Proc_ChenThemGiangVien";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@magv", tbTeacherID.Text);
                            command.Parameters.AddWithValue("@tengv", tbTeacherName.Text);
                            command.Parameters.AddWithValue("@gioitinh", gender);
                            command.Parameters.AddWithValue("@ngaysinh", dtpDateOfBirth.Text);
                            command.Parameters.AddWithValue("@makhoa", cbDepartment.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Thêm mới giảng viên thành công", "Thông báo");
                            clearInputControl();
                            loadDataToGridView();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Giảng viên đã tồn tại trong hệ thống", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isTeacherIDExist(string teacherId)
        {
            string query = "Proc_KiemTraGiangVien";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@magv", teacherId);

                    connection.Open();
                    var result = command.ExecuteScalar();
                    connection.Close();

                    if (result == null)
                    {
                        return false;
                    }

                    return true;
                }
            }
        }

        private void clearInputControl()
        {
            tbTeacherID.Text = String.Empty;
            tbTeacherName.Text = String.Empty;
            rdMale.Checked = true;
            dtpDateOfBirth.Value = DateTime.Today;
            cbDepartment.ResetText();
            toggleDisableButton();
            tbTeacherID.ReadOnly = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInputControl();
            toggleDisableButton();
            loadDataToGridView();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                string teacherId = tbTeacherID.Text;
                if (isTeacherIDExist(teacherId))
                {
                    string query = "Select * From tblGiangVien";
                    string gender = genderOfTeacher();
                    

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.Text;

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dtTeacher = new DataTable("tblGiangVien"))
                                {
                                    adapter.Fill(dtTeacher);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dtTeacher);
                                        dtTeacher.PrimaryKey = new DataColumn[] { dtTeacher.Columns["sMaGV"] };

                                        DataRow newRow = dtTeacher.Rows.Find(tbTeacherID.Text);
                                        newRow["sMaGV"] = tbTeacherID.Text;
                                        newRow["sTenGV"] = tbTeacherName.Text;
                                        newRow["sGioiTinh"] = gender;
                                        newRow["dNgaySinh"] = dtpDateOfBirth.Text;
                                        newRow["sMaKhoa"] = cbDepartment.Text;

                                        query = "Proc_CapNhattblGiangVien";
                                        command.CommandText = query;
                                        command.CommandType = CommandType.StoredProcedure;

                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@magv", tbTeacherID.Text);
                                        command.Parameters.AddWithValue("@tengv", tbTeacherName.Text);
                                        command.Parameters.AddWithValue("@gioitinh", gender);
                                        command.Parameters.AddWithValue("@ngaysinh", dtpDateOfBirth.Text);
                                        command.Parameters.AddWithValue("@makhoa", cbDepartment.Text);

                                        adapter.UpdateCommand = command;
                                        adapter.Update(dataSet, "tblGiangVien");
                                        MessageBox.Show("Cập nhật thông tin thành công", "Thông báo");
                                        clearInputControl();
                                        loadDataToGridView();
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Không tồn tại giảng viên cần sửa trong hệ thống", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string teacherId = tbTeacherID.Text;
                if (isTeacherIDExist(teacherId))
                {
                    string query = "Proc_XoaGiangVienVaCapNhatGiangVienMonHoc";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@magv", tbTeacherID.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Xoá thành công giảng viên có mã " + teacherId, "Thông báo");
                            loadDataToGridView();
                            clearInputControl();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại giảng viên cần xoá trong hệ thống", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "sMaGV IS NOT NULL";
            if (!string.IsNullOrEmpty(tbTeacherID.Text))
            {
                filter += string.Format(" AND sMaGV LIKE '{0}'", tbTeacherID.Text);
            }
            loadDataToGridView(filter);
        }

        private void báoCáoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string teacherId = tbTeacherID.Text;
                if (isTeacherIDExist(teacherId))
                {
                    fReport report = new fReport();
                    report.Show();
                    report.showTeacherDetailReport(teacherId);

                }
                else
                {
                    MessageBox.Show("Không tồn tại giảng viên!", "Thông báo");
                    clearInputControl();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void giớiTínhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fReport fReport =new fReport();
            fReport.Show();
            fReport.showTeacherGroupForGender();
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fReport fReport = new fReport();
            fReport.Show();
            fReport.showTeacherGroupForDepartment();
        }
    }
}
