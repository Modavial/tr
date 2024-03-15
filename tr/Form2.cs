using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tr
{

    public partial class Form2 : Form
    {

        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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
            admin_chat ach = new admin_chat();
            ach.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                var sql = "CALL delete_user(" + textBox1.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Enter id!";
            }
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                var sql = "CALL delete_buyer(" + textBox1.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Enter id!";
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                var sql = "CALL delete_order(" + textBox1.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Enter id!";
            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                var sql = "CALL delete_item(" + textBox1.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Enter id!";
            }
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                var sql = "CALL delete_application(" + textBox1.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Enter id!";
            }
            con.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                var sql = "CALL delete_history(" + textBox1.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Enter id!";
            }
            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                var sql = "CALL delete_user(" + textBox1.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Enter id!";
            }
            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                var sql = "CALL delete_catalog(" + textBox1.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Enter id!";
            }
            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                var sql = "CALL delete_reviews(" + textBox1.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                label2.Text = "Enter id!";
            }
            con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            applications ap = new applications();
            ap.Text = this.Text;
            ap.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                if ((textBox2.Text != "") && (textBox3.Text != "") && (textBox4.Text != ""))
                {
                    label7.Text = "";
                    var sql = "call add_login ('" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ")";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                    var dataReader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    cmd.Dispose();
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                else
                {
                    label7.Text = "Fill all fields";
                }
            }
            catch
            {
                label7.Text = "Add error";
            }
            con.Close();
        }
    }
}
