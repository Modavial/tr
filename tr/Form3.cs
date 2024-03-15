using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tr
{
    public partial class Form3 : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
            buyerpersonal bp = new buyerpersonal();
            bp.Text = this.Text;
            bp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            items it = new items();
            it.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                label1.Text = "";
                var sql = "call add_item_to_catalog('" + this.Text + "'," + textBox1.Text+")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                label1.Text = "Error";
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "select * from orders where buyer_nick = '" + this.Text + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "select * from applications where buyer_nickname = '" + this.Text + "'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {
            order oc = new order();
            oc.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "Select * from reviews where buyer_nick = '" + this.Text +"'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
