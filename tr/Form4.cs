using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tr
{
    public partial class Form4 : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form1 = (Form1)Tag;
            form1.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chat ch = new Chat();
            ch.Text = this.Text;
            ch.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userpersonal bp = new userpersonal();
            bp.Text = this.Text;
            bp.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "select * from recommend_view('"+this.Text+"')";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "select * from free_buyers";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "Select * from applications where user_nickname ='"+this.Text+"'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            createapplication ca = new createapplication();
            ca.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            order oc = new order();
            oc.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "Select * from orders where user_nick ='" + this.Text + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            viewbuyerpersonal bp = new viewbuyerpersonal();
            bp.Text = textBox1.Text;
            bp.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            items it = new items();
            it.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "Select * from items";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "Select * from reviews";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            newreview nr = new newreview();
            nr.ShowDialog();
        }
    }
}
