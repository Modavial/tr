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
    public partial class buyerpersonal : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public buyerpersonal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            int pass;
            var sql = $"Select buyer_id from buyers where buyer_nickname = '{this.Text}'";
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
            if (pass!=0)
            {
                sql = "call update_buyer("+ pass.ToString() + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','{" + textBox6.Text + "}','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "')";
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
                sql = "call add_buyer('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text+ "','" + textBox4.Text + "','" + textBox5.Text+"','{" + textBox6.Text +"}','"+ textBox7.Text+"','" + textBox8.Text+"','" + textBox9.Text +"')";
                NpgsqlCommand upbuyer = new NpgsqlCommand(sql, con);
                var sql2 = "call add_catalog ('"+textBox5.Text+"')";
                NpgsqlCommand upcatalog = new NpgsqlCommand(sql2, con);
                try
                {
                    label10.Text = "";
                    upbuyer.ExecuteNonQuery();
                    upcatalog.ExecuteNonQuery();
                }
                catch
                {
                    label10.Text = "Enter correct data!";
                }
            }
            con.Close();
        }

        private void buyerpersonal_Load(object sender, EventArgs e)
        {
            con.Open();
            var infoload = "select * from buyers where buyer_nickname = '" + this.Text +"'";
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
                textBox8.Text = dt.Rows[0][8].ToString();
                textBox9.Text = dt.Rows[0][9].ToString();
            }
            catch { textBox5.Text = this.Text; }
            con.Close();
        }
    }
}
