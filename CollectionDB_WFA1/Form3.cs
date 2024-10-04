using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionDB_WFA1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string constr = ("Server=localhost;Database=VideoGameCollection;Trusted_Connection=True");
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name, Franchise, Developer, Platform, Released, Special_Edition, CiB, Played, Beaten, Favorite FROM Games WHERE Name = '" + Form1.entry + "'", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text = reader.GetString(0);
                    textBox2.Text = reader.GetString(1);
                    textBox3.Text = reader.GetString(2);
                    textBox4.Text = reader.GetString(3);
                    dateTimePicker1.Value = reader.GetDateTime(4);
                    checkBox1.Checked = reader.GetBoolean(5);
                    checkBox2.Checked = reader.GetBoolean(6);
                    checkBox3.Checked = reader.GetBoolean(7);
                    checkBox4.Checked = reader.GetBoolean(8);
                    checkBox5.Checked = reader.GetBoolean(9);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = ("Server=localhost;Database=VideoGameCollection;Trusted_Connection=True");
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("dbo.Games_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Franchise", textBox2.Text);
                cmd.Parameters.AddWithValue("@Developer", textBox3.Text);
                cmd.Parameters.AddWithValue("@Platform", textBox4.Text);
                cmd.Parameters.AddWithValue("@Released", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Special_Edition", checkBox1.Checked);
                cmd.Parameters.AddWithValue("@CiB", checkBox2.Checked);
                cmd.Parameters.AddWithValue("@Played", checkBox3.Checked);
                cmd.Parameters.AddWithValue("@Beaten", checkBox4.Checked);
                cmd.Parameters.AddWithValue("@Favorite", checkBox5.Checked);
                try
                {
                    con.Open();
                    Int32 rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("RowsAffected: {0}", rowsAffected);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Close();
        }
    }
}
