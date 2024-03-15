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
    public partial class admin_chat : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public admin_chat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if ((textBox1.Text.Length != 0)&&(textBox2.Text.Length!=0))
            {
                label3.Text = "";
                var sql = "select * from view_chat_admin('" + textBox1.Text + "', '" + textBox2.Text + "')";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                var dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView1.DataSource = dt;
            }
            else
            {
                label3.Text = "Enter users nicknames";
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox3.Text.Length!=0)
            {
                var sql = "CALL delete_message(" + textBox3.Text + ")";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label8.Text = "";
            }
            else
            {
                label8.Text = "Enter id!";
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            if ((textBox3.Text.Length != 0) && (textBox4.Text.Length != 0) && (textBox5.Text.Length != 0) && (textBox6.Text.Length != 0))
            {
                var sql = "CALL update_message(" + textBox3.Text + ", '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                label8.Text = "";
            }
            else
            {
                label8.Text = "Fill all paramentres!";
            }
            con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
