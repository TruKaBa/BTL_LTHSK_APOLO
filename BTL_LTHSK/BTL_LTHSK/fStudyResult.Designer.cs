namespace BTL_LTHSK
{
    partial class fStudyResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoChiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoThôngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbStudentID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbTeacherID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbSubjectID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbPresencePoint = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbMidTermPoint = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbExamPoint = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.dgvStudyResult = new System.Windows.Forms.DataGridView();
            this.sMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sMaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDiemCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDiemGK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fDiemThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudyResult)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(739, 28);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoChiTiếtToolStripMenuItem,
            this.báoCáoThôngKêToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // báoCáoChiTiếtToolStripMenuItem
            // 
            this.báoCáoChiTiếtToolStripMenuItem.Name = "báoCáoChiTiếtToolStripMenuItem";
            this.báoCáoChiTiếtToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.báoCáoChiTiếtToolStripMenuItem.Text = "Báo cáo chi tiết";
            // 
            // báoCáoThôngKêToolStripMenuItem
            // 
            this.báoCáoThôngKêToolStripMenuItem.Name = "báoCáoThôngKêToolStripMenuItem";
            this.báoCáoThôngKêToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.báoCáoThôngKêToolStripMenuItem.Text = "Báo cáo thông kê";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbStudentID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 43);
            this.panel1.TabIndex = 14;
            // 
            // tbStudentID
            // 
            this.tbStudentID.Location = new System.Drawing.Point(163, 7);
            this.tbStudentID.Name = "tbStudentID";
            this.tbStudentID.Size = new System.Drawing.Size(323, 22);
            this.tbStudentID.TabIndex = 0;
            this.tbStudentID.TextChanged += new System.EventHandler(this.tbStudentID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sinh viên:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbTeacherID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 43);
            this.panel2.TabIndex = 15;
            // 
            // tbTeacherID
            // 
            this.tbTeacherID.Location = new System.Drawing.Point(163, 9);
            this.tbTeacherID.Name = "tbTeacherID";
            this.tbTeacherID.Size = new System.Drawing.Size(323, 22);
            this.tbTeacherID.TabIndex = 1;
            this.tbTeacherID.TextChanged += new System.EventHandler(this.tbTeacherID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã giảng viên:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbSubjectID);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(532, 43);
            this.panel3.TabIndex = 16;
            // 
            // tbSubjectID
            // 
            this.tbSubjectID.Location = new System.Drawing.Point(163, 9);
            this.tbSubjectID.Name = "tbSubjectID";
            this.tbSubjectID.Size = new System.Drawing.Size(323, 22);
            this.tbSubjectID.TabIndex = 1;
            this.tbSubjectID.TextChanged += new System.EventHandler(this.tbSubjectID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã môn:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tbPresencePoint);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 158);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(532, 43);
            this.panel4.TabIndex = 17;
            // 
            // tbPresencePoint
            // 
            this.tbPresencePoint.Location = new System.Drawing.Point(163, 7);
            this.tbPresencePoint.Name = "tbPresencePoint";
            this.tbPresencePoint.Size = new System.Drawing.Size(188, 22);
            this.tbPresencePoint.TabIndex = 0;
            this.tbPresencePoint.TextChanged += new System.EventHandler(this.tbPresencePoint_TextChanged);
            this.tbPresencePoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPresencePoint_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Điểm CC";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tbMidTermPoint);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(12, 199);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(532, 43);
            this.panel5.TabIndex = 18;
            // 
            // tbMidTermPoint
            // 
            this.tbMidTermPoint.Location = new System.Drawing.Point(163, 7);
            this.tbMidTermPoint.Name = "tbMidTermPoint";
            this.tbMidTermPoint.Size = new System.Drawing.Size(188, 22);
            this.tbMidTermPoint.TabIndex = 0;
            this.tbMidTermPoint.TextChanged += new System.EventHandler(this.tbMidTermPoint_TextChanged);
            this.tbMidTermPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMidTermPoint_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Điểm GK";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tbExamPoint);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(12, 241);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(532, 43);
            this.panel6.TabIndex = 19;
            // 
            // tbExamPoint
            // 
            this.tbExamPoint.Location = new System.Drawing.Point(163, 7);
            this.tbExamPoint.Name = "tbExamPoint";
            this.tbExamPoint.Size = new System.Drawing.Size(188, 22);
            this.tbExamPoint.TabIndex = 0;
            this.tbExamPoint.TextChanged += new System.EventHandler(this.tbExamPoint_TextChanged);
            this.tbExamPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExamPoint_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Điểm thi:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnCancel);
            this.panel7.Controls.Add(this.btnAdd);
            this.panel7.Controls.Add(this.btnSearch);
            this.panel7.Controls.Add(this.btnDelete);
            this.panel7.Controls.Add(this.btnChange);
            this.panel7.Location = new System.Drawing.Point(550, 31);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(184, 253);
            this.panel7.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(26, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(26, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 42);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(26, 148);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 42);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(26, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 42);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(26, 52);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(122, 42);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "Sửa";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // dgvStudyResult
            // 
            this.dgvStudyResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudyResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudyResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMaSV,
            this.sMaGV,
            this.sMaMon,
            this.fDiemCC,
            this.fDiemGK,
            this.fDiemThi});
            this.dgvStudyResult.Location = new System.Drawing.Point(0, 363);
            this.dgvStudyResult.Name = "dgvStudyResult";
            this.dgvStudyResult.RowHeadersWidth = 51;
            this.dgvStudyResult.RowTemplate.Height = 24;
            this.dgvStudyResult.Size = new System.Drawing.Size(739, 313);
            this.dgvStudyResult.TabIndex = 21;
            this.dgvStudyResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudyResult_CellClick);
            // 
            // sMaSV
            // 
            this.sMaSV.DataPropertyName = "sMaSV";
            this.sMaSV.HeaderText = "Mã SV";
            this.sMaSV.MinimumWidth = 6;
            this.sMaSV.Name = "sMaSV";
            // 
            // sMaGV
            // 
            this.sMaGV.DataPropertyName = "sMaGV";
            this.sMaGV.HeaderText = "Mã GV";
            this.sMaGV.MinimumWidth = 6;
            this.sMaGV.Name = "sMaGV";
            // 
            // sMaMon
            // 
            this.sMaMon.DataPropertyName = "sMaMon";
            this.sMaMon.HeaderText = "Mã môn";
            this.sMaMon.MinimumWidth = 6;
            this.sMaMon.Name = "sMaMon";
            // 
            // fDiemCC
            // 
            this.fDiemCC.DataPropertyName = "fDiemCC";
            this.fDiemCC.HeaderText = "Điểm CC";
            this.fDiemCC.MinimumWidth = 6;
            this.fDiemCC.Name = "fDiemCC";
            // 
            // fDiemGK
            // 
            this.fDiemGK.DataPropertyName = "fDiemGK";
            this.fDiemGK.HeaderText = "Điểm GK";
            this.fDiemGK.MinimumWidth = 6;
            this.fDiemGK.Name = "fDiemGK";
            // 
            // fDiemThi
            // 
            this.fDiemThi.DataPropertyName = "fDiemThi";
            this.fDiemThi.HeaderText = "Điểm thi";
            this.fDiemThi.MinimumWidth = 6;
            this.fDiemThi.Name = "fDiemThi";
            // 
            // fStudyResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 675);
            this.Controls.Add(this.dgvStudyResult);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fStudyResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết quả học tập";
            this.Load += new System.EventHandler(this.fStudyResult_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudyResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoChiTiếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoThôngKêToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbStudentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbPresencePoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tbMidTermPoint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbExamPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.DataGridView dgvStudyResult;
        private System.Windows.Forms.TextBox tbTeacherID;
        private System.Windows.Forms.TextBox tbSubjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn fDiemCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn fDiemGK;
        private System.Windows.Forms.DataGridViewTextBoxColumn fDiemThi;
    }
}