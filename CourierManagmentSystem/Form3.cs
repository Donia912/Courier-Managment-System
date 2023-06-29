﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace CourierManagmentSystem
{
    public partial class Form3 : Form
    {
        CrystalReport1 CR;
        CrystalReport2 CR2;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport1();
            CR2 = new CrystalReport2();
            foreach (ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
                comboBox1.Items.Add(v.Value);
            foreach (ParameterDiscreteValue x in CR.ParameterFields[0].DefaultValues)
                comboBox2.Items.Add(x.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CR2.SetParameterValue(0, comboBox2.Text);
            crystalReportViewer1.ReportSource = CR2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = CR;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
