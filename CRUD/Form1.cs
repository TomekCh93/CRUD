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

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=PC030\WINCC;Initial Catalog=Crud;Integrated Security=True"); // path with connection string
        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand command = new SqlCommand("insert into ProductInfo_Tab values('" + int.Parse(textBox4.Text) + "','" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "', getDate())", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted");
            con.Close();
            BindData();
        }

        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from ProductInfo_Tab", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        private void Form1_Load_1(object sender, EventArgs e)
        {
            BindData();
        }

        private void UpdButton_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("update ProductInfo_Tab set ItemName = '" + textBox1.Text + "', Design = '" + textBox2.Text + "', Color = '" + comboBox1.Text + "',UpdateDate = getdate() where ProductID = '" + int.Parse(textBox4.Text) + "'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");
            BindData();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are u sure to delete?", "Delte record", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                if (textBox4.Text != "")
                {

                    con.Open();
                    SqlCommand command = new SqlCommand("Delete ProductInfo_Tab where ProductID = '" + int.Parse(textBox4.Text) + "'", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Delted");
                    BindData();
                }
                else
                {
                    MessageBox.Show("Put Product ID");
                }
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from ProductInfo_Tab where ProductID = '" + int.Parse(textBox4.Text) + "'", con);
                SqlDataAdapter sd = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception exp)
            {

 
                MessageBox.Show("There is no record in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
    }
}

