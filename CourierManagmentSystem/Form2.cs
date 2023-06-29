using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace CourierManagmentSystem
{
    public partial class Form2 : Form
    {
        // Initialize OracleDataAdapter, OracleCommandBuilder, and DataSet
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Code to execute when the form is loaded
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Connect to Oracle database using connection string and select data from Shipments table
            string constr = "Data Source = orcl; User Id = cms; Password = 123";
            string cmdstr = "select * from Shipments where shipment_id = :x";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("x", textBox1.Text);
            ds = new DataSet();
            adapter.Fill(ds);

            // Bind the data to the DataGridView control
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Code to execute when the text in the textBox1 control changes
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Code to execute when a cell in the dataGridView1 control is clicked
        }

        private void save_Click(object sender, EventArgs e)
        {
            // Automatically generate SQL commands to update the database when changes are made to the DataSet
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }
    }
}