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
    public partial class userpersonal : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public userpersonal()
        {
            InitializeComponent();
        }

        private void userpersonal_Load(object sender, EventArgs e)
        {
            con.Open();
            var infoload = "select * from users where user_nickname = '" + this.Text + "'";
            NpgsqlCommand infload = new NpgsqlCommand(infoload, con);
            var dataReader = infload.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            try
            {
            textBox1.Text = dt.Rows[0][1].ToString();
            textBox2.Text = dt.Rows[0][2].ToString();
            textBox3.Text = dt.Rows[0][3].ToString();
            textBox4.Text = dt.Rows[0][4].ToString();
            textBox5.Text = dt.Rows[0][5].ToString();
            textBox6.Text = dt.Rows[0][6].ToString();
            textBox7.Text = dt.Rows[0][7].ToString();
            }
            catch { textBox5.Text = this.Text; }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            int pass;
            var sql = $"Select user_id from users where user_nickname = '{this.Text}'";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dataReader);
            try
            {
                pass = Int32.Parse(dt.Rows[0][0].ToString());
            }
            catch
            {
                pass = 0;
            }
            if (pass != 0)
            {
                sql = "call update_user(" + pass.ToString() + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','{" + textBox6.Text + "}','" + textBox7.Text + "')";
                NpgsqlCommand upbuyer = new NpgsqlCommand(sql, con);
                try
                {
                    label10.Text = "";
                    upbuyer.ExecuteNonQuery();
                }
                catch
                {
                    label10.Text = "Enter correct data!";
                }
            }
            else
            {
                label10.Text = "";
                sql = "call add_user('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','{" + textBox6.Text + "}','" + textBox7.Text + "')";
                NpgsqlCommand upbuyer = new NpgsqlCommand(sql, con);
                try
                {
                    label10.Text = "";
                    upbuyer.ExecuteNonQuery();
                }
                catch
                {
                    label10.Text = "Enter correct data!";
                }
            }
            con.Close();
        }
    }
}
