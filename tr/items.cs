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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tr
{
    public partial class items : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public items()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                label8.Text = "";
                var sql = "call add_item(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + ",'" + textBox6.Text + "')";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                label8.Text = "Error";
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                label8.Text = "";
                var sql = "call update_item("+textBox7.Text+"," + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + ",'" + textBox6.Text + "')";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                label8.Text = "Error";
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                label8.Text = "";
                var sql = "call delete_item(" +textBox7.Text+ ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                label8.Text = "Error";
            }
            con.Close();
        }
    }
}
