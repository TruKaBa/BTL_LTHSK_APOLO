namespace LeThanhTrung
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.cbMonHoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbLopHc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDiemCC = new System.Windows.Forms.TextBox();
            this.tbDiemGk = new System.Windows.Forms.TextBox();
            this.tbDiemCuoiKy = new System.Windows.Forms.TextBox();
            this.btnTinhDiem = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.rtbKetQua = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(468, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Điểm giữa kỳ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ và tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Môn học";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbDiemCuoiKy);
            this.groupBox1.Controls.Add(this.tbDiemGk);
            this.groupBox1.Controls.Add(this.tbDiemCC);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbLopHc);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbMonHoc);
            this.groupBox1.Controls.Add(this.tbTen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(785, 228);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // tbTen
            // 
            this.tbTen.Location = new System.Drawing.Point(129, 34);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(289, 27);
            this.tbTen.TabIndex = 3;
            // 
            // cbMonHoc
            // 
            this.cbMonHoc.FormattingEnabled = true;
            this.cbMonHoc.Items.AddRange(new object[] {
            "Cơ sở dữ liệu",
            "Hệ quản trị cơ sở dữ liệu",
            "Kiến trúc máy tính",
            "Lập trình hướng đối tượng",
            "Lập trình hướng sự kiện",
            "Phân tích thiết kế hệ thống"});
            this.cbMonHoc.Location = new System.Drawing.Point(129, 79);
            this.cbMonHoc.Name = "cbMonHoc";
            this.cbMonHoc.Size = new System.Drawing.Size(289, 28);
            this.cbMonHoc.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(468, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Lớp HC";
            // 
            // cbLopHc
            // 
            this.cbLopHc.FormattingEnabled = true;
            this.cbLopHc.Items.AddRange(new object[] {
            "1910A01",
            "1910A02",
            "1910A03",
            "1910A04",
            "1910A05"});
            this.cbLopHc.Location = new System.Drawing.Point(579, 34);
            this.cbLopHc.Name = "cbLopHc";
            this.cbLopHc.Size = new System.Drawing.Size(170, 28);
            this.cbLopHc.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(468, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Điểm chuyên cần";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(468, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Điểm cuối kỳ";
            // 
            // tbDiemCC
            // 
            this.tbDiemCC.Location = new System.Drawing.Point(636, 84);
            this.tbDiemCC.Name = "tbDiemCC";
            this.tbDiemCC.Size = new System.Drawing.Size(113, 27);
            this.tbDiemCC.TabIndex = 9;
            this.tbDiemCC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDiemCC_KeyPress);
            // 
            // tbDiemGk
            // 
            this.tbDiemGk.Location = new System.Drawing.Point(636, 127);
            this.tbDiemGk.Name = "tbDiemGk";
            this.tbDiemGk.Size = new System.Drawing.Size(113, 27);
            this.tbDiemGk.TabIndex = 10;
            this.tbDiemGk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDiemGk_KeyPress);
            // 
            // tbDiemCuoiKy
            // 
            this.tbDiemCuoiKy.Location = new System.Drawing.Point(636, 169);
            this.tbDiemCuoiKy.Name = "tbDiemCuoiKy";
            this.tbDiemCuoiKy.Size = new System.Drawing.Size(113, 27);
            this.tbDiemCuoiKy.TabIndex = 11;
            this.tbDiemCuoiKy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDiemCuoiKy_KeyPress);
            // 
            // btnTinhDiem
            // 
            this.btnTinhDiem.Location = new System.Drawing.Point(210, 263);
            this.btnTinhDiem.Name = "btnTinhDiem";
            this.btnTinhDiem.Size = new System.Drawing.Size(112, 40);
            this.btnTinhDiem.TabIndex = 4;
            this.btnTinhDiem.Text = "Tính điểm";
            this.btnTinhDiem.UseVisualStyleBackColor = true;
            this.btnTinhDiem.Click += new System.EventHandler(this.btnTinhDiem_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(466, 263);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(112, 40);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTiepTuc
            // 
            this.btnTiepTuc.Location = new System.Drawing.Point(337, 263);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(112, 40);
            this.btnTiepTuc.TabIndex = 6;
            this.btnTiepTuc.Text = "Tiếp tục";
            this.btnTiepTuc.UseVisualStyleBackColor = true;
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 341);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Kết quả";
            // 
            // rtbKetQua
            // 
            this.rtbKetQua.Location = new System.Drawing.Point(35, 377);
            this.rtbKetQua.Name = "rtbKetQua";
            this.rtbKetQua.Size = new System.Drawing.Size(726, 270);
            this.rtbKetQua.TabIndex = 9;
            this.rtbKetQua.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 669);
            this.Controls.Add(this.rtbKetQua);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnTiepTuc);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnTinhDiem);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Điểm học tập của sinh viên";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMonHoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbLopHc;
        private System.Windows.Forms.TextBox tbDiemCuoiKy;
        private System.Windows.Forms.TextBox tbDiemGk;
        private System.Windows.Forms.TextBox tbDiemCC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnTinhDiem;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnTiepTuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtbKetQua;
    }
}

