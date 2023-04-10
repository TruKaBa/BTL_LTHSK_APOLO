using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTL_LTHSK
{
    public partial class fClass : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        private DataView dataView = new DataView();

        public fClass()
        {
            InitializeComponent();
        }

        private void fClass_Load(object sender, EventArgs e)
        {
           toggleDisableButton();
           loadDataToComboBoxTeacher();
           loadDataToComboBoxDepartment();
           loadDataToGridView();
        }

        private void tbClassID_TextChanged(object sender, EventArgs e)
        {
            if (tbClassID.Text.Length > 0)
            {
                toggleDisableButton(true, true, true, true, true);
            } else
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

        private void loadDataToComboBoxTeacher()
        {
            try
            {
                string proc = "Select * from tblGiangVien";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = conn.CreateCommand())
                    {
                        command.CommandText = proc;
                        command.CommandType = CommandType.Text;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dtTeacheer = new DataTable())
                            {
                                adapter.Fill(dtTeacheer);
                                if (dtTeacheer.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dtTeacheer.Rows)
                                    {
                                        cbTeacher.Items.Add(row["sMaGV"]);
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
                                } else
                                {
                                    MessageBox.Show("Không tồn tại bản ghi nào");
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

        private void loadDataToGridView(string filter = "")
        {
            try
            {
                string query = "Proc_SelectAlltblLopHC";
                using (SqlConnection connection = new SqlConnection(connectionString))
                { 
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText= query;
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dtClass = new DataTable())
                            {
                                
                                adapter.Fill(dtClass);

                                if (dtClass.Rows.Count > 0)
                                {
                                    dataView = dtClass.DefaultView;
                                    

                                    dgvClass.DataSource = dataView;
                                    dgvClass.Columns["sMaLop"].ReadOnly = true;
                                    dgvClass.Columns["sTenLop"].ReadOnly = true;
                                    dgvClass.Columns["sMaGV"].ReadOnly = true;
                                    dgvClass.Columns["sMaKhoa"].ReadOnly = true;

                                    if (!string.IsNullOrEmpty(filter)) dataView.RowFilter = filter;

                                } else
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

        private void dgvClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvClass.CurrentRow.Index;
            tbClassID.Text = dataView[index]["sMaLop"].ToString();
            tbClassName.Text = dataView[index]["sTenLop"].ToString();
            cbTeacher.Text = dataView[index]["sMaGV"].ToString();
            cbDepartment.Text = dataView[index]["sMaKhoa"].ToString();

            tbClassID.ReadOnly = true;
            toggleDisableButton(changeButton: true, deleteButton: true, searchButton: true, cancelButton: true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string classId = tbClassID.Text;
                if (!isClassIDExist(classId))
                {
                    string query = "Proc_ChenThemLop";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@malop", tbClassID.Text);
                            command.Parameters.AddWithValue("@tenlop", tbClassName.Text);
                            command.Parameters.AddWithValue("@magv", cbTeacher.Text);
                            command.Parameters.AddWithValue("@makhoa", cbDepartment.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Thêm mới lớp hành chính thành công");
                            clearInputControl();
                        }
                    }
                } else
                {
                    MessageBox.Show("Đã tồn tại mã lớp trong CSDL", "Thông báo");
                }


            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool isClassIDExist(string classId)
        {
                string query = "Proc_KiemTraMaLop";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@malop", classId);

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
            tbClassID.Text = String.Empty;
            tbClassName.Text = String.Empty;
            cbTeacher.ResetText();
            cbDepartment.ResetText();
            toggleDisableButton();
            tbClassID.ReadOnly = false;
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
                string classId = tbClassID.Text;
                if (isClassIDExist(classId))
                {
                    string query = "Select * from tblLopHC";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.Text;

                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                using (DataTable dtLopHC = new DataTable("tblLopHC"))
                                {
                                    adapter.Fill(dtLopHC);
                                    using (DataSet dataSet = new DataSet())
                                    {
                                        dataSet.Tables.Add(dtLopHC);
                                        dtLopHC.PrimaryKey = new DataColumn[] { dtLopHC.Columns["sMaLop"] };

                                        DataRow newRow = dtLopHC.Rows.Find(tbClassID.Text);
                                        newRow["sMaLop"] = tbClassID.Text;
                                        newRow["sTenLop"] = tbClassName.Text;
                                        newRow["sMaGV"] = cbTeacher.Text;
                                        newRow["sMaKhoa"] = cbDepartment.Text;

                                        query = "Proc_CapNhattblLopHC";
                                        command.CommandText = query;
                                        command.CommandType = CommandType.StoredProcedure;

                                        command.Parameters.Clear();
                                        command.Parameters.AddWithValue("@malop", tbClassID.Text);
                                        command.Parameters.AddWithValue("@tenlop", tbClassName.Text);
                                        command.Parameters.AddWithValue("@magv", cbTeacher.Text);
                                        command.Parameters.AddWithValue("@makhoa", cbDepartment.Text);

                                        adapter.UpdateCommand = command;
                                        adapter.Update(dataSet, "tblLopHC");
                                        MessageBox.Show("Cập nhật thông tin thành công", "Thông báo");
                                        clearInputControl();
                                        loadDataToGridView();
                                    }
                                }
                            }
                        }
                    }

                } else
                {
                    MessageBox.Show("Không tồn tại mã lớp cần sửa trong CSDL", "Thông báo");
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string classId = tbClassID.Text;
                if (isClassIDExist(classId))
                {
                    string query = "Proc_XoaLopSinhVien";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@malop", tbClassID.Text);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            query = "Proc_XoaLop";
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            query = "SELECT TOP 1 sMaLop FROM tblLopHC ORDER BY sMaLop DESC ";
                            command.CommandText = query;
                            command.CommandType = CommandType.Text;

                            connection.Open();
                            string lastClassId = (string)command.ExecuteScalar();
                            connection.Close();

                            query = "Proc_CapNhatLopChoSinhVien";
                            command.CommandText = query;
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@malop", lastClassId);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Xoá thành công lớp có mã " + classId +", các sinh viên của lớp đã được chuyển sang lớp có mã " + lastClassId, "Thông báo");
                            loadDataToGridView();
                            clearInputControl();
                        }
                    }
                } else
                {
                    MessageBox.Show("Không tồn tại lớp cần xoá trong CSDL", "Thông báo");
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = "sMaLop IS NOT NULL";
            if (!string.IsNullOrEmpty(tbClassID.Text))
            {
                filter += string.Format(" AND sMaLop LIKE '{0}'", tbClassID.Text);
            }
            loadDataToGridView(filter);
        }

        private void báoCáoĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            try
            {
                string classId = tbClassID.Text;
                if (isClassIDExist(classId))
                {
                    fReport report = new fReport(classId);
                    report.Show();
                    report.showDetailClassReport(classId);
          
                } else
                {
                    MessageBox.Show("Không tồn tại mã lớp!", "Thông báo");
                    clearInputControl();
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fReport fReport = new fReport();
            fReport.Show();
            fReport.showGroupClassReport();
        }
    }    
    }

