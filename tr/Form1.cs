using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace tr
{
    public partial class Form1 : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            if ((textBox1.Text!="")&&(textBox2.Text!=""))
            {
                int pass;
                var sql = "Select login_group from login_table where user_nickname = '" + textBox1.Text + "' and user_password = '" + textBox2.Text + "'";
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
                    switch (pass)
                    {
                        case 1:
                            Form2 form2 = new Form2();
                            form2.Tag = this;
                            form2.Text = textBox1.Text;
                            form2.Show(this);
                            Hide();
                            break;
                        case 2:
                            Form3 form3 = new Form3();
                            form3.Tag = this;
                            form3.Text = textBox1.Text;
                            form3.Show(this);
                            Hide();
                            break;
                        case 3:
                            Form4 form4 = new Form4();
                            form4.Tag = this;
                            form4.Text = textBox1.Text;
                            form4.Show(this);
                            Hide();
                            break;
                    }
                    label4.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    label4.Text = "Wrong login or password";
                }
            }
            else
            {
                label4.Text = "Enter login and password";
            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
