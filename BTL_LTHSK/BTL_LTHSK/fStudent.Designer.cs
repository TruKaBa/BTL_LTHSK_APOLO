namespace BTL_LTHSK
{
    partial class fStudent
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoChiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoThốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.theoLớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbStudentID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbStudentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdFemale = new System.Windows.Forms.RadioButton();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tbStudentAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tbStudentPhoneNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.sMaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sTenSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dNgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sLopHC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnAdd);
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.btnDelete);
            this.panel5.Controls.Add(this.btnChange);
            this.panel5.Location = new System.Drawing.Point(550, 31);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(184, 304);
            this.panel5.TabIndex = 11;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(39, 250);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Huỷ";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(39, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(122, 42);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(39, 192);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(122, 42);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(39, 134);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 42);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(39, 70);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(122, 42);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "Sửa";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(743, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoChiTiếtToolStripMenuItem,
            this.báoCáoThốngKêToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // báoCáoChiTiếtToolStripMenuItem
            // 
            this.báoCáoChiTiếtToolStripMenuItem.Name = "báoCáoChiTiếtToolStripMenuItem";
            this.báoCáoChiTiếtToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.báoCáoChiTiếtToolStripMenuItem.Text = "Báo cáo chi tiết";
            this.báoCáoChiTiếtToolStripMenuItem.Click += new System.EventHandler(this.báoCáoChiTiếtToolStripMenuItem_Click);
            // 
            // báoCáoThốngKêToolStripMenuItem
            // 
            this.báoCáoThốngKêToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.báoCáoToolStripMenuItem1,
            this.theoLớpToolStripMenuItem});
            this.báoCáoThốngKêToolStripMenuItem.Name = "báoCáoThốngKêToolStripMenuItem";
            this.báoCáoThốngKêToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.báoCáoThốngKêToolStripMenuItem.Text = "Báo cáo thống kê";
            // 
            // báoCáoToolStripMenuItem1
            // 
            this.báoCáoToolStripMenuItem1.Name = "báoCáoToolStripMenuItem1";
            this.báoCáoToolStripMenuItem1.Size = new System.Drawing.Size(184, 26);
            this.báoCáoToolStripMenuItem1.Text = "Theo giới tinh";
            this.báoCáoToolStripMenuItem1.Click += new System.EventHandler(this.báoCáoToolStripMenuItem1_Click);
            // 
            // theoLớpToolStripMenuItem
            // 
            this.theoLớpToolStripMenuItem.Name = "theoLớpToolStripMenuItem";
            this.theoLớpToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.theoLớpToolStripMenuItem.Text = "Theo lớp";
            this.theoLớpToolStripMenuItem.Click += new System.EventHandler(this.theoLớpToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbStudentID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 43);
            this.panel1.TabIndex = 13;
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
            this.panel2.Controls.Add(this.tbStudentName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 43);
            this.panel2.TabIndex = 14;
            // 
            // tbStudentName
            // 
            this.tbStudentName.Location = new System.Drawing.Point(163, 9);
            this.tbStudentName.Name = "tbStudentName";
            this.tbStudentName.Size = new System.Drawing.Size(323, 22);
            this.tbStudentName.TabIndex = 0;
            this.tbStudentName.TextChanged += new System.EventHandler(this.tbStudentName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên sinh viên:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rdFemale);
            this.panel3.Controls.Add(this.rdMale);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 124);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(532, 43);
            this.panel3.TabIndex = 15;
            // 
            // rdFemale
            // 
            this.rdFemale.AutoSize = true;
            this.rdFemale.Location = new System.Drawing.Point(241, 10);
            this.rdFemale.Name = "rdFemale";
            this.rdFemale.Size = new System.Drawing.Size(45, 20);
            this.rdFemale.TabIndex = 4;
            this.rdFemale.Text = "Nữ";
            this.rdFemale.UseVisualStyleBackColor = true;
            // 
            // rdMale
            // 
            this.rdMale.AutoSize = true;
            this.rdMale.Checked = true;
            this.rdMale.Location = new System.Drawing.Point(163, 9);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(57, 20);
            this.rdMale.TabIndex = 3;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "Nam";
            this.rdMale.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giới tính:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtpDateOfBirth);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(12, 166);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(532, 43);
            this.panel4.TabIndex = 16;
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.CustomFormat = "dd/MM/yyyy";
            this.dtpDateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateOfBirth.Location = new System.Drawing.Point(163, 7);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(200, 22);
            this.dtpDateOfBirth.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày sinh:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tbStudentAddress);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(12, 208);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(532, 43);
            this.panel6.TabIndex = 17;
            // 
            // tbStudentAddress
            // 
            this.tbStudentAddress.Location = new System.Drawing.Point(163, 9);
            this.tbStudentAddress.Name = "tbStudentAddress";
            this.tbStudentAddress.Size = new System.Drawing.Size(323, 22);
            this.tbStudentAddress.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Địa chỉ:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.tbStudentPhoneNumber);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(12, 250);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(532, 43);
            this.panel7.TabIndex = 18;
            // 
            // tbStudentPhoneNumber
            // 
            this.tbStudentPhoneNumber.Location = new System.Drawing.Point(163, 9);
            this.tbStudentPhoneNumber.Name = "tbStudentPhoneNumber";
            this.tbStudentPhoneNumber.Size = new System.Drawing.Size(323, 22);
            this.tbStudentPhoneNumber.TabIndex = 0;
            this.tbStudentPhoneNumber.TextChanged += new System.EventHandler(this.tbStudentPhoneNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "SDT:";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.cbClass);
            this.panel8.Controls.Add(this.label7);
            this.panel8.Location = new System.Drawing.Point(12, 292);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(532, 43);
            this.panel8.TabIndex = 19;
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(163, 7);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(200, 24);
            this.cbClass.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Lớp hành chính:";
            // 
            // dgvStudent
            // 
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sMaSV,
            this.sTenSV,
            this.sGioiTinh,
            this.dNgaySinh,
            this.sSDT,
            this.sDiaChi,
            this.sLopHC});
            this.dgvStudent.Location = new System.Drawing.Point(0, 391);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 51;
            this.dgvStudent.RowTemplate.Height = 24;
            this.dgvStudent.Size = new System.Drawing.Size(743, 294);
            this.dgvStudent.TabIndex = 20;
            this.dgvStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellClick);
            // 
            // sMaSV
            // 
            this.sMaSV.DataPropertyName = "sMaSV";
            this.sMaSV.HeaderText = "Mã SV";
            this.sMaSV.MinimumWidth = 6;
            this.sMaSV.Name = "sMaSV";
            this.sMaSV.Width = 125;
            // 
            // sTenSV
            // 
            this.sTenSV.DataPropertyName = "sTenSV";
            this.sTenSV.HeaderText = "Tên SV";
            this.sTenSV.MinimumWidth = 6;
            this.sTenSV.Name = "sTenSV";
            this.sTenSV.Width = 125;
            // 
            // sGioiTinh
            // 
            this.sGioiTinh.DataPropertyName = "sGioiTinh";
            this.sGioiTinh.HeaderText = "Giới Tính";
            this.sGioiTinh.MinimumWidth = 6;
            this.sGioiTinh.Name = "sGioiTinh";
            this.sGioiTinh.Width = 125;
            // 
            // dNgaySinh
            // 
            this.dNgaySinh.DataPropertyName = "dNgaySinh";
            this.dNgaySinh.HeaderText = "Ngày Sinh";
            this.dNgaySinh.MinimumWidth = 6;
            this.dNgaySinh.Name = "dNgaySinh";
            this.dNgaySinh.Width = 125;
            // 
            // sSDT
            // 
            this.sSDT.DataPropertyName = "sSDT";
            this.sSDT.HeaderText = "SDT";
            this.sSDT.MinimumWidth = 6;
            this.sSDT.Name = "sSDT";
            this.sSDT.Width = 125;
            // 
            // sDiaChi
            // 
            this.sDiaChi.DataPropertyName = "sDiaChi";
            this.sDiaChi.HeaderText = "Địa Chỉ";
            this.sDiaChi.MinimumWidth = 6;
            this.sDiaChi.Name = "sDiaChi";
            this.sDiaChi.Width = 125;
            // 
            // sLopHC
            // 
            this.sLopHC.DataPropertyName = "sLopHC";
            this.sLopHC.HeaderText = "Lớp HC";
            this.sLopHC.MinimumWidth = 6;
            this.sLopHC.Name = "sLopHC";
            this.sLopHC.Width = 125;
            // 
            // fStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 687);
            this.Controls.Add(this.dgvStudent);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sinh viên";
            this.Load += new System.EventHandler(this.fStudent_Load);
            this.panel5.ResumeLayout(false);
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
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoChiTiếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoThốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem theoLớpToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbStudentID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbStudentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tbStudentAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox tbStudentPhoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdFemale;
        private System.Windows.Forms.RadioButton rdMale;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn sMaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn sTenSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn sGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dNgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn sLopHC;
    }
}