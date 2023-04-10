﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_LTHSK
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lophcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fClass fClass = new fClass();
            this.Hide();
            fClass.ShowDialog();
            this.Show();
        }

        private void giảngViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fTeacher fTeacher = new fTeacher();
            this.Hide();
            fTeacher.ShowDialog();
            this.Show();
        }
    }
}
