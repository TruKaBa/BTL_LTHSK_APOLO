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
    public partial class fSubject : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        private ErrorProvider errorProvider = new ErrorProvider();
        private DataView dataView = new DataView();

        public fSubject()
        {
            InitializeComponent();
        }

        private void fSubject_Load(object sender, EventArgs e)
        {
            toggleDisableButton();
            loadDataToComboBoxDepartment();
            loadDataToGridView();
        }

        private void tbSubjectID_TextChanged(object sender, EventArgs e)
        {
            if (tbSubjectID.Text.Length > 0)
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

        private void tbSubjectName_TextChanged(object sender, EventArgs e)
        {
            if (hasNumberInName(tbSubjectName.Text))
            {
                errorProvider.SetError(tbSubjectName, "Tên không được chứa chữ số");
                toggleDisableButton(cancelButton: true);

            }
            else
            {
                errorProvider.SetError(tbSubjectName, null);
            }
        }

        private bool hasNumberInName(string subjectName)
        {
            bool result = subjectName.Any(char.IsDigit);
            return result;
        }

        private int numberOfCreidts()
        {
            int result = 3;
            if (rdFourCredits.Checked)
            {
                result = 4;
                return result;
            }
            return result;
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

        private void loadDataToGridView(string filter = "")
        {
            try
            {
                string query = "Proc_SelectAlltblMonHoc";
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

                                    dgvSubject.DataSource = dataView;
                                    dgvSubject.Columns["sMaMon"].ReadOnly = true;
                                    dgvSubject.Columns["sTenMon"].ReadOnly = true;
                                    dgvSubject.Columns["iSoTC"].ReadOnly = true;
                                    dgvSubject.Columns["sMaKhoa"].ReadOnly = true;

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

        private void dgvSubject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int defaultCredits = 3;
            int index = dgvSubject.CurrentRow.Index;
            tbSubjectID.Text = dataView[index]["sMaMon"].ToString();
            tbSubjectName.Text = dataView[index]["sTenMon"].ToString();

            if (Int32.Parse(dataView[index]["iSoTC"].ToString()) == defaultCredits)
            {
                rdThreeCredits.Checked = true;
            }
            else
            {
                rdFourCredits.Checked = true;
            }
            cbDepartment.Text = dataView[index]["sMaKhoa"].ToString();

            tbSubjectID.ReadOnly = true;
            toggleDisableButton(changeButton: true, deleteButton: true, searchButton: true, cancelButton: true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string subjectId = tbSubjectID.Text;
                int numberOfCredit = numberOfCreidts();

                if (!isSubjectIDExist(subjectId))
                {
                    string query = "Proc_ChenThemMonHoc";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@mamon", tbSubjectID.Text);
                            command.Parameters.AddWithValue("@tenmon", tbSubjectName.Text);
                            command.Parameters.AddWithValue("@makhoa", cbDepartment.Text);
                            command.Parameters.AddWithValue("@sotinchi", numberOfCredit);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Thêm mới môn học thành công", "Thông báo");
                            clearInputControl();
                            loadDataToGridView();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Môn học đã tồn tại trong hệ thống", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isSubjectIDExist(string subjectId)
        {
            string query = "Proc_KiemTraMonHoc";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@mamon", subjectId);

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
            tbSubjectID.Text = String.Empty;
            tbSubjectName.Text = String.Empty;
            rdThreeCredits.Checked = true;
            cbDepartment.ResetText();
            toggleDisableButton();
            tbSubjectID.ReadOnly = false;
            tbSubjectID.Focus();
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
                string subjectId = tbSubjectID.Text;
                if (isSubjectIDExist(subjectId))
                {
                    string query = "Select * From tblMonHoc";
                    int numberOfCredit = numberOfCreidts();


                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.Text;

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dtSubject = new DataTable("tblMonHoc"))
                                {
                                    adapter.Fill(dtSubject);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dtSubject);
                                        dtSubject.PrimaryKey = new DataColumn[] { dtSubject.Columns["sMaMon"] };

                                        DataRow newRow = dtSubject.Rows.Find(tbSubjectID.Text);
                                        newRow["sMaMon"] = tbSubjectID.Text;
                                        newRow["sMaKhoa"] = cbDepartment.Text;
                                        newRow["sTenMon"] = tbSubjectName.Text;
                                        newRow["iSoTC"] = numberOfCredit;
                                        

                                        query = "Proc_CapNhattblMonHoc";
                                        command.CommandText = query;
                                        command.CommandType = CommandType.StoredProcedure;

                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@mamon", tbSubjectID.Text);
                                        command.Parameters.AddWithValue("@tenmon", tbSubjectName.Text);
                                        command.Parameters.AddWithValue("@makhoa", cbDepartment.Text);
                                        command.Parameters.AddWithValue("@sotinchi", numberOfCredit);

                                        adapter.UpdateCommand = command;
                                        adapter.Update(dataSet, "tblMonHoc");
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
                    MessageBox.Show("Không tồn tại môn học cần sửa trong hệ thống", "Thông báo");
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
                string subjectId = tbSubjectID.Text;
                if (isSubjectIDExist(subjectId))
                {
                    string query = "Proc_XoaMonHocVaCapNhatMonHocChoSinhVien";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@mamon", tbSubjectID.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Xoá thành công môn học có mã " + subjectId, "Thông báo");
                            loadDataToGridView();
                            clearInputControl();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tồn tại môn học cần xoá trong hệ thống", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "sMaMon IS NOT NULL";
            if (!string.IsNullOrEmpty(tbSubjectID.Text))
            {
                filter += string.Format(" AND sMaMon LIKE '{0}'", tbSubjectID.Text);
            }
            loadDataToGridView(filter);
        }
    }
}
