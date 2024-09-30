using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Collections;
using System.Data.Common;

namespace CollectionDB_WFA1
{
    public partial class Form1 : Form
    {
        string constr = ("Server=localhost;Database=VideoGameCollection;Trusted_Connection=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = new Thread(RunNewForm);
            t.Start();
        }
        public static void RunNewForm()
        {
            Application.Run(new Form2());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> nameData = new List<string>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Games", con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nameData.Add(reader.GetString(0));
                    }
                }
                listBox1.DataSource = nameData;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Games WHERE Name = " + "'" + listBox1.Text + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<string> nameData = new List<string>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Games ORDER BY " + comboBox1.Text, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nameData.Add(reader.GetString(0));
                    }
                }
                listBox1.DataSource = nameData;
            }
        }
    }
    class SQLCon
    {

    }
}
