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
    public partial class Chat : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public Chat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if (textBox1.Text.Length != 0)
            {
                label4.Text = "";
                var sql = "select * from view_chat('" + this.Text + "', '" + textBox1.Text + "')";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                var dataReader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dataReader);
                dataGridView1.DataSource = dt;
            }
            else
            {
                label4.Text = "Enter user nickname";
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "CALL add_message('" + textBox2.Text + "', '" + this.Text + "', '" + textBox3.Text+"')";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            if (textBox3.Text.Length>0)
            {
                if ((textBox2.Text.Length>0)&&(textBox2.Text.Length<=200))
                {
                    label4.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    label4.Text = "Enter message!";
                }
            }
            else
            {
                label4.Text = "Enter recipient!";
            }
            con.Close();
        }

        private void Chat_Load(object sender, EventArgs e)
        {

        }
    }
}
