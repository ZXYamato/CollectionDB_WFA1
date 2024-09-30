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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string constr = ("Server=localhost;Database=VideoGameCollection;Trusted_Connection=True");
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("dbo.Games_Add", con);
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
                //SqlDataReader rdr = cmd.ExecuteReader();
            }
            Close();
        }
    }
}
