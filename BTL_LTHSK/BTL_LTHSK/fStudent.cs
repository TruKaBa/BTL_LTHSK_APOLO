using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTHSK
{
    public partial class fStudent : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        private ErrorProvider errorProvider = new ErrorProvider();
        private DataView dataView = new DataView();

        public fStudent()
        {
            InitializeComponent();
        }

        private void fStudent_Load(object sender, EventArgs e)
        {
            toggleDisableButton();
            loadDataToComboBoxClass();
            loadDataToGridView();
        }

        private void tbStudentID_TextChanged(object sender, EventArgs e)
        {
            if (tbStudentID.Text.Length > 0)
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

        private bool hasNumberInName(string studentName)
        {
            bool result = studentName.Any(char.IsDigit);
            return result;
        }

        private bool hasLetterInPhoneNumber(string phoneNumber)
        {
            bool result = phoneNumber.Any(char.IsLetter);
            return result;
        }

        private void tbStudentName_TextChanged(object sender, EventArgs e)
        {
            if (hasNumberInName(tbStudentName.Text))
            {
                errorProvider.SetError(tbStudentName, "Tên sinh viên không được chứa chữ số");
                toggleDisableButton(cancelButton: true);

            }
            else
            {
                errorProvider.SetError(tbStudentName, null);
            }
        }

        private void tbStudentPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (hasLetterInPhoneNumber(tbStudentPhoneNumber.Text))
            {
                errorProvider.SetError(tbStudentPhoneNumber, "SDT không được chứa chữ cái");
              

            }
            else
            {
                errorProvider.SetError(tbStudentPhoneNumber, null);
            }
        }

        private void loadDataToComboBoxClass()
        {
            try
            {
                string proc = "Proc_SelectAlltblLopHC";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = proc;
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dtClass = new DataTable())
                            {
                                adapter.Fill(dtClass);
                                if (dtClass.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dtClass.Rows)
                                    {
                                        cbClass.Items.Add(row["sMaLop"]);
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

        private void loadDataToGridView(string filter = "")
        {
            try
            {
                string query = "Proc_SelectAlltblSinhVien";
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

                                    dgvStudent.DataSource = dataView;
                                    dgvStudent.AutoGenerateColumns = false;

                                    dgvStudent.Columns["sMaSV"].ReadOnly = true;
                                    dgvStudent.Columns["sTenSV"].ReadOnly = true;
                                    dgvStudent.Columns["sGioiTinh"].ReadOnly = true;
                                    dgvStudent.Columns["dNgaySinh"].ReadOnly = true;
                                    dgvStudent.Columns["sDiaChi"].ReadOnly = true;
                                    dgvStudent.Columns["sSDT"].ReadOnly = true;
                                    dgvStudent.Columns["sLopHC"].ReadOnly = true;

                                    if (!string.IsNullOrEmpty(filter)) dataView.RowFilter = filter;
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

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvStudent.CurrentRow.Index;
            tbStudentID.Text = dataView[index]["sMaSV"].ToString();
            tbStudentName.Text = dataView[index]["sTenSV"].ToString();

            if (isMale(dataView[index]["sGioiTinh"].ToString()))
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }
            DateTime dateOfBirth = formatDateOfBirth(dataView[index]["dNgaySinh"].ToString());
            dtpDateOfBirth.Value = dateOfBirth;
            tbStudentAddress.Text = dataView[index]["sDiaChi"].ToString();
            tbStudentPhoneNumber.Text = dataView[index]["sSDT"].ToString();
            cbClass.Text = dataView[index]["sLopHC"].ToString();

            tbStudentID.ReadOnly = true;
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

        private DateTime formatDateOfBirth(string dateOfBirth)
        {
            DateTime result = Convert.ToDateTime(dateOfBirth);
            return result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string studentId = tbStudentID.Text;
                string gender = genderOfStudent();
               

                if (!isStudentIDExist(studentId))
                {
                    string query = "Proc_ChenThemSinhVien";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@masv", tbStudentID.Text);
                            command.Parameters.AddWithValue("@tensv", tbStudentName.Text);
                            command.Parameters.AddWithValue("@gioitinh", gender);
                            command.Parameters.AddWithValue("@ngaysinh", dtpDateOfBirth.Text);
                            command.Parameters.AddWithValue("@diachi", tbStudentAddress.Text);
                            command.Parameters.AddWithValue("@sdt", tbStudentPhoneNumber.Text);
                            command.Parameters.AddWithValue("@malop", cbClass.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Thêm mới sinh viên thành công", "Thông báo");
                            clearInputControl();
                            loadDataToGridView();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sinh viên đã tồn tại trong hệ thống", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isStudentIDExist(string studentId)
        {
            string query = "Proc_KiemTraSinhVien";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@masv", studentId);

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
            tbStudentID.Text = String.Empty;
            tbStudentName.Text = String.Empty;
            rdMale.Checked = true;
            dtpDateOfBirth.Value = DateTime.Today;
            tbStudentAddress.Text = String.Empty;
            tbStudentPhoneNumber.Text = String.Empty;
            cbClass.ResetText();
            toggleDisableButton();
            tbStudentID.ReadOnly = false;
            tbStudentID.Focus();
        }

        private string genderOfStudent()
        {
            string result = "Nữ";
            if (rdMale.Checked)
            {
                result = "Nam";
                return result;
            }
            return result;
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
                string studentId = tbStudentID.Text;
                if (isStudentIDExist(studentId))
                {
                    string query = "Select * From tblSinhVien";
                    string gender = genderOfStudent();


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.Text;

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dtStudent = new DataTable("tblSinhVien"))
                                {
                                    adapter.Fill(dtStudent);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dtStudent);
                                        dtStudent.PrimaryKey = new DataColumn[] { dtStudent.Columns["sMaSV"] };

                                        DataRow newRow = dtStudent.Rows.Find(tbStudentID.Text);
                                        newRow["sMaSV"] = tbStudentID.Text;
                                        newRow["sTenSV"] = tbStudentName.Text;
                                        newRow["sGioiTinh"] = gender;
                                        newRow["dNgaySinh"] = dtpDateOfBirth.Text;
                                        newRow["sDiaChi"] = tbStudentAddress.Text;
                                        newRow["sSDT"] = tbStudentPhoneNumber.Text;
                                        newRow["sLopHC"] = cbClass.Text;

                                        query = "Proc_CapNhattblSinhVien";
                                        command.CommandText = query;
                                        command.CommandType = CommandType.StoredProcedure;

                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@masv", tbStudentID.Text);
                                        command.Parameters.AddWithValue("@tensv", tbStudentName.Text);
                                        command.Parameters.AddWithValue("@gioitinh", gender);
                                        command.Parameters.AddWithValue("@ngaysinh", dtpDateOfBirth.Text);
                                        command.Parameters.AddWithValue("@diachi", tbStudentAddress.Text);
                                        command.Parameters.AddWithValue("@sdt", tbStudentPhoneNumber.Text);
                                        command.Parameters.AddWithValue("@malop", cbClass.Text);

                                        adapter.UpdateCommand = command;
                                        adapter.Update(dataSet, "tblSinhVien");
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
                    MessageBox.Show("Không tồn tại sinh viên cần sửa trong hệ thống", "Thông báo");
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
                string studentId = tbStudentID.Text;
                if (isStudentIDExist(studentId))
                {
                    string query = "Proc_XoaSinhVien";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@masv", tbStudentID.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Xoá thành công sinh viên có mã " + studentId, "Thông báo");
                            loadDataToGridView();
                            clearInputControl();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại sinh viên cần xoá trong hệ thống", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "sMaSV IS NOT NULL";
            if (!string.IsNullOrEmpty(tbStudentID.Text))
            {
                filter += string.Format(" AND sMaSV LIKE '{0}'", tbStudentID.Text);
            }
            loadDataToGridView(filter);
        }

        private void báoCáoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string studentId = tbStudentID.Text;
                if (isStudentIDExist(studentId))
                {
                    fReport report = new fReport();
                    report.Show();
                    report.showStudentDetail(studentId);

                }
                else
                {
                    MessageBox.Show("Không tồn tại sinh viên!", "Thông báo");
                    clearInputControl();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void báoCáoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fReport fReport = new fReport();
            fReport.Show();
            fReport.showStudentGroupForGender();
        }

        private void theoLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fReport fReport = new fReport();
            fReport.Show();
            fReport.showStudentGroupForClass();
        }
    }
}
