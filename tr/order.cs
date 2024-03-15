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
    public partial class order : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public order()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "call add_order('{"+textBox1.Text+"}','"+textBox2.Text+"','"+textBox3.Text+"','"+ textBox4.Text +"','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                label6.Text = "";
            }
            catch { label6.Text = "Wrong order"; }
            con.Close();
        }

        private void order_Load(object sender, EventArgs e)
        {

        }
    }
}
