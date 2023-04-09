using CrystalDecisions.CrystalReports.Engine;
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
    public partial class fReport : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectString"].ConnectionString;
        private string classId;

        public fReport()
        {
            InitializeComponent();
        }
        public fReport(string classId)
        {
            InitializeComponent();
            this.classId = classId;
        }

        public void showDetailClassReport(string classId)
        {
            try
            {
                string query = "Proc_ChiTietLopHC";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@malop", classId);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dtResult = new DataTable())
                            {
                                adapter.Fill(dtResult);
                                ReportDocument reportDocument = new ReportDocument();

                                string path = string.Format("{0}\\Reports\\fClassReports\\DetailReport.rpt", Application.StartupPath);
                                reportDocument.Load(path);
                                reportDocument.Database.Tables[query].SetDataSource(dtResult);

                                crystalReportView.ReportSource = reportDocument;
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void showGroupClassReport()
        {
            try
            {
                string query = "Proc_LopHCTheoKhoa";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = query;
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (DataTable dtResult = new DataTable())
                            {
                                adapter.Fill(dtResult);
                                ReportDocument reportDocument = new ReportDocument();

                                string path = string.Format("{0}\\Reports\\fClassReports\\GroupReport.rpt", Application.StartupPath);
                                reportDocument.Load(path);
                                reportDocument.Database.Tables[query].SetDataSource(dtResult);

                                crystalReportView.ReportSource = reportDocument;
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
    }
}
