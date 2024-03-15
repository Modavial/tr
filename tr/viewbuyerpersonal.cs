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
    public partial class viewbuyerpersonal : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public viewbuyerpersonal()
        {
            InitializeComponent();
        }

        private void viewbuyerpersonal_Load(object sender, EventArgs e)
        {
            con.Open();
            var infoload = "select * from buyers where buyer_nickname = '" + this.Text + "'";
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
            var catalogload = "select * from buyer_catalog where buyer_nick = '" + this.Text + "'";
            NpgsqlCommand catalog = new NpgsqlCommand(catalogload, con);
            dataReader = catalog.ExecuteReader();
            dt = new DataTable();
            dt.Load(dataReader);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
