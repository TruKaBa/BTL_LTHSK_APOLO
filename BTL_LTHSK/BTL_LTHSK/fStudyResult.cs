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
    public partial class fStudyResult : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        private ErrorProvider errorProvider = new ErrorProvider();
        private DataView dataView = new DataView();
       
        public fStudyResult()
        {
            InitializeComponent();
        }

        private void fStudyResult_Load(object sender, EventArgs e)
        {
            loadDataToGridView();
        }

        private void loadDataToGridView(string filter = "")
        {
            try
            {
                string query = "Proc_SelectAlltblHoc";
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

                                    dgvStudyResult.DataSource = dataView;

                                    dgvStudyResult.Columns["sMaSV"].ReadOnly = true;
                                    dgvStudyResult.Columns["sMaGV"].ReadOnly = true;
                                    dgvStudyResult.Columns["sMaMon"].ReadOnly = true;
                                    dgvStudyResult.Columns["fDiemCC"].ReadOnly = true;
                                    dgvStudyResult.Columns["fDiemGK"].ReadOnly = true;
                                    dgvStudyResult.Columns["fDiemThi"].ReadOnly = true;


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

        private void toggleDisableButton(bool addButton = false, bool changeButton = false, bool deleteButton = false, bool searchButton = false, bool cancelButton = false)
        {
            btnAdd.Enabled = addButton;
            btnChange.Enabled = changeButton;
            btnDelete.Enabled = deleteButton;
            btnSearch.Enabled = searchButton;
            btnCancel.Enabled = cancelButton;
        }

        private void tbPresencePoint_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbMidTermPoint_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbExamPoint_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tbStudentID_TextChanged(object sender, EventArgs e)
        {
            string studentId = tbStudentID.Text;
            if (!isStudentIDExist(studentId) && studentId.Length > 0)
            {
                errorProvider.SetError(tbStudentID, "Không tồn tại sinh viên trong hệ thống");
            } else
            {
                errorProvider.SetError(tbStudentID,null);
                toggleDisableButton(true, true, true, true, true);
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

        private void tbTeacherID_TextChanged(object sender, EventArgs e)
        {
            string teacherId = tbTeacherID.Text;
            if (!isTeacherIDExist(teacherId) && teacherId.Length > 0)
            {
                errorProvider.SetError(tbTeacherID, "Không tồn tại giảng viên trong hệ thống");
            }
            else
            {
                errorProvider.SetError(tbTeacherID, null);
                
            }
        }

        private void tbSubjectID_TextChanged(object sender, EventArgs e)
        {
            string subjectId = tbSubjectID.Text;
            if (!isSubjectIDExist(subjectId) && subjectId.Length > 0)
            {
                errorProvider.SetError(tbSubjectID, "Không tồn tại môn học trong hệ thống");
            }
            else
            {
                errorProvider.SetError(tbSubjectID, null);
        
            }
        }

        private void dgvStudyResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvStudyResult.CurrentRow.Index;
            tbStudentID.Text = dataView[index]["sMaSV"].ToString();
            tbTeacherID.Text = dataView[index]["sMaGV"].ToString();
            tbSubjectID.Text = dataView[index]["sMaMon"].ToString();
            tbPresencePoint.Text = dataView[index]["fDiemCC"].ToString();
            tbMidTermPoint.Text = dataView[index]["fDiemGK"].ToString();
            tbExamPoint.Text = dataView[index]["fDiemThi"].ToString();

            tbStudentID.ReadOnly = true;
            tbTeacherID.ReadOnly = true;
            tbSubjectID.ReadOnly = true;
            toggleDisableButton(changeButton: true, deleteButton: true, searchButton: true, cancelButton: true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearInputControl();
            loadDataToGridView();
            
            tbSubjectID.ReadOnly = false;
            tbStudentID.ReadOnly = false;
            tbTeacherID.ReadOnly = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (!isPointOverTennAndUnderZero())
                {
                    string query = "Proc_ChenKetQuaHocTap";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@masv", tbStudentID.Text);
                            command.Parameters.AddWithValue("@magv", tbTeacherID.Text);
                            command.Parameters.AddWithValue("@mamon", tbSubjectID.Text);
                            command.Parameters.AddWithValue("@diemcc", float.Parse(tbPresencePoint.Text));
                            command.Parameters.AddWithValue("@diemgk", float.Parse(tbMidTermPoint.Text));
                            command.Parameters.AddWithValue("@diemthi", float.Parse(tbExamPoint.Text));

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Thêm mới thành công", "Thông báo");
                            clearInputControl();
                            loadDataToGridView();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Điểm không được dưới 0 hoặc trên 10", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool isPointOverTennAndUnderZero()
        {
            float presencePoint = float.Parse(tbPresencePoint.Text);
            float midTermPoint = float.Parse(tbMidTermPoint.Text);
            float examPoint = float.Parse(tbExamPoint.Text);
            
            if ((presencePoint < 0) || (midTermPoint < 0) || (examPoint < 0) || (presencePoint > 10) || (midTermPoint > 10) || (examPoint > 10))
            {
                return true;
            }
            return false;
        }

        private void clearInputControl()
        {
            tbStudentID.Text = String.Empty;
            tbTeacherID.Text = String.Empty;
            tbSubjectID.Text = String.Empty;
            tbPresencePoint.Text = String.Empty;
            tbMidTermPoint.Text = String.Empty;
            tbExamPoint.Text = String.Empty;
            tbStudentID.ReadOnly = false;
            tbSubjectID.ReadOnly = false;
            tbTeacherID.ReadOnly = false;
            tbStudentID.Focus();
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

        private void tbPresencePoint_TextChanged(object sender, EventArgs e)
        {
            if (tbPresencePoint.Text != String.Empty)
            {
                float presenecePoint = float.Parse(tbPresencePoint.Text);
                if (presenecePoint < 0 || presenecePoint > 10)
                {
                    errorProvider.SetError(tbPresencePoint, "Điểm không được dưới 0 hoặc trên 10");
                }
                else
                {
                    errorProvider.SetError(tbPresencePoint, null);

                }
            }
        }

        private void tbMidTermPoint_TextChanged(object sender, EventArgs e)
        {
            if (tbMidTermPoint.Text != String.Empty)
            {
                float midTermPoinnt = float.Parse(tbMidTermPoint.Text);
                if (midTermPoinnt < 0 || midTermPoinnt > 10)
                {
                    errorProvider.SetError(tbMidTermPoint, "Điểm không được dưới 0 hoặc trên 10");
                }
                else
                {
                    errorProvider.SetError(tbMidTermPoint, null);

                }
            }
        }

        private void tbExamPoint_TextChanged(object sender, EventArgs e)
        {
            if (tbExamPoint.Text != String.Empty)
            {
                float examPoint = float.Parse(tbExamPoint.Text);
                if (examPoint < 0 || examPoint > 10)
                {
                    errorProvider.SetError(tbExamPoint, "Điểm không được dưới 0 hoặc trên 10");
                }
                else
                {
                    errorProvider.SetError(tbExamPoint, null);

                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {

                if (!isPointOverTennAndUnderZero())
                {
                    string query = "Proc_CapNhatKetQuaHocTap";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@masv", tbStudentID.Text);
                            command.Parameters.AddWithValue("@magv", tbTeacherID.Text);
                            command.Parameters.AddWithValue("@mamon", tbSubjectID.Text);
                            command.Parameters.AddWithValue("@diemcc", float.Parse(tbPresencePoint.Text));
                            command.Parameters.AddWithValue("@diemgk", float.Parse(tbMidTermPoint.Text));
                            command.Parameters.AddWithValue("@diemthi", float.Parse(tbExamPoint.Text));

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Cập nhật thành công", "Thông báo");
                            clearInputControl();
                            loadDataToGridView();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Điểm không được dưới 0 hoặc trên 10", "Thông báo");
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

                if (!isPointOverTennAndUnderZero())
                {
                    string query = "Proc_XoaKetQuaHocTap";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@masv", tbStudentID.Text);
                            command.Parameters.AddWithValue("@magv", tbTeacherID.Text);
                            command.Parameters.AddWithValue("@mamon", tbSubjectID.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Xoá thành công", "Thông báo");
                            clearInputControl();
                            loadDataToGridView();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Điểm không được dưới 0 hoặc trên 10", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
