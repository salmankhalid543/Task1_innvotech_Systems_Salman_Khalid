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

namespace crudForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BRHQGE3\\SQLEXPRESS01;Initial Catalog=crudForm;Integrated Security=True;trustservercertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand( "Insert into student values(@id,@name,@address,@salary)",con );
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text) );
            cmd.Parameters.AddWithValue("@name", (textBox3.Text));
            cmd.Parameters.AddWithValue("@address", (textBox4.Text));
            cmd.Parameters.AddWithValue("@salary", double.Parse(textBox2.Text) );
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Successfully Created");


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Read
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BRHQGE3\\SQLEXPRESS01;Initial Catalog=crudForm;Integrated Security=True;trustservercertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student where id = @id",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BRHQGE3\\SQLEXPRESS01;Initial Catalog=crudForm;Integrated Security=True;trustservercertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update student set name = @name,salary = @salary, address=@address where id = @id",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@name", (textBox3.Text));
            cmd.Parameters.AddWithValue("@address", (textBox4.Text));
            cmd.Parameters.AddWithValue("@salary", double.Parse(textBox2.Text));
            cmd.ExecuteNonQuery ();
            con.Close();

            MessageBox.Show(" Updated Successfully");

        }

        private void button4_Click(object sender, EventArgs e)
        { 
            //delete
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BRHQGE3\\SQLEXPRESS01;Initial Catalog=crudForm;Integrated Security=True;trustservercertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete student where id = @id",con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery ();
            con.Close();

            MessageBox.Show(" Deleted Successfully");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Show All
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BRHQGE3\\SQLEXPRESS01;Initial Catalog=crudForm;Integrated Security=True;trustservercertificate=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student", con);
            cmd.Parameters.AddWithValue("@id", (textBox1.Text));
            cmd.Parameters.AddWithValue("@name", (textBox3.Text));
            cmd.Parameters.AddWithValue("@address", (textBox4.Text));
            cmd.Parameters.AddWithValue("@salary", (textBox2.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            MessageBox.Show(" Showed all Successfully");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Exit
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-BRHQGE3\\SQLEXPRESS01;Initial Catalog=crudForm;Integrated Security=True;trustservercertificate=True");
            con.Open();
            Application.Exit();
            con.Close() ;
        }
    }
}
