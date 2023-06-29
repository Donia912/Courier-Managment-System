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
    public partial class Form1 : Form
    {
        string ordb = "Data source=orcl;User Id=user1;Password=123;";
        OracleConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select order_id from Orders";
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Select.Items.Add(dr[0]);
            }

            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select item_description, order_status from Orders where order_id = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", Select.SelectedItem.ToString());

            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
            }

            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Orders values(:order_id, :pick_up_address, :delivery_address, :item_description, :weight, :quantity, :delivery_cost, :order_status, :DP_id, :CustomerID)";
            cmd.Parameters.Add("order_id", Select.Text.ToString());
            cmd.Parameters.Add("pick_up_address", textBox3.Text.ToString());
            cmd.Parameters.Add("delivery_address", textBox4.Text.ToString());
            cmd.Parameters.Add("item_description", textBox1.Text.ToString());
            cmd.Parameters.Add("weight", textBox5.Text.ToString());
            cmd.Parameters.Add("quantity", textBox6.Text.ToString());
            cmd.Parameters.Add("delivery_cost", textBox7.Text.ToString());
            cmd.Parameters.Add("order_status", textBox2.Text.ToString());
            cmd.Parameters.Add("DP_id", textBox8.Text.ToString());
            cmd.Parameters.Add("CustomerID", textBox9.Text.ToString());

            int r = cmd.ExecuteNonQuery();

            if (r != -1)
            {
                Select.Items.Add(Select.Text);
                MessageBox.Show("New Order is added");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECTION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("orderid", textBox10.Text.ToString() );
            cmd.Parameters.Add("deliverycost", OracleDbType.Int64  );
            cmd.Parameters["deliverycost"].Direction = ParameterDirection.Output;
            int r = cmd.ExecuteNonQuery();

            if (r != -1)
            {
                textBox11.Text = Convert.ToString(cmd.Parameters["deliverycost"].Value);
                MessageBox.Show("sus");
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELIVERYPERSONORDERS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("DeliveryID", textBox12.Text);
            cmd.Parameters.Add("ordersassign", OracleDbType.RefCursor,ParameterDirection.Output);
            comboBox1.Items.Clear();
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read()){

                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form2 = new Form2();
            Form2.Show();
        }
        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start start = new Start();
            start.Show();
        }
    }
}