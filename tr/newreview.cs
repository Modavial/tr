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
    public partial class newreview : Form
    {
        public const string cs = "Host=localhost;Username=postgres;Password=privet123;Database=TR";
        public NpgsqlConnection con = new NpgsqlConnection(cs);
        public newreview()
        {
            InitializeComponent();
        }

        private void newreview_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            var sql = "call add_review('" + textBox1.Text + "'," + textBox2.Text + ",'" + textBox3.Text + "')";
            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
            try {
                cmd.ExecuteNonQuery();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                label4.Text = "";
            }
            catch { label4.Text = "Error"; }
            con.Close();
        }
    }
}
