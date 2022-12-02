using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace STDBMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=STDDB;Integrated Security=True;";
        

        private void Form1_Load(object sender, EventArgs e)
        {
            //step 1 Create SQL Connection
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionstring;
            connection.Open();

            //step 2 Create sql command

            SqlCommand commands = new SqlCommand();
            commands.Connection = connection;

            // step 3 run quesries
            commands.CommandText = @"SELECT *FROM stdDB";
            SqlDataReader datareader = commands.ExecuteReader();
            
            while (datareader.Read())
            {

                listBox1.Items.Add(datareader.GetValue(0));
            }
            
            
        }
        public void reset()
        {
            textBox1.Text = "First Name";
            textBox2.Text = "Last Name";
            textBox3.Text = "City";
            textBox4.Text = "State";
            textBox5.Text = "Country";
            textBox6.Text = "Nationality";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //step 1 Create SQL Connection

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionstring;
            connection.Open();

            //step 2 Create sql command

            SqlCommand commands = new SqlCommand();
            commands.Connection = connection;
            int i = 2;


            // step 3 run quesries


            
            commands.CommandType = CommandType.Text;
            commands.CommandText = "INSERT into stdDB (First_Name,Last_Name,City,State,Country,Nationality) VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')";


            
            commands.ExecuteNonQuery();
            MessageBox.Show("SuccessFully Updated");
            listBox1.Items.Add(textBox1.Text);
            reset();
            i++;
            connection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //step 1 Create SQL Connection
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionstring;
            connection.Open();

            //step 2 Create sql command

            SqlCommand commands = new SqlCommand("delete from stdDb where First_Name=@First_Name");
            commands.Connection = connection;
            commands.Parameters.AddWithValue("@First_Name",textBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(commands);
            DataSet ds = new DataSet();
            da.Fill(ds);
            MessageBox.Show("Deleted Successfully");
            connection.Close();

            listBox1.Items.Remove(textBox1.Text);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //step 1 Create SQL Connection
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionstring;
            connection.Open();

              //step 2 Create sql command

            SqlCommand commands = new SqlCommand();
            commands.Connection = connection;

            // step 3 run quesries
                    SqlCommand command = new SqlCommand("Update stdDb set First_Name=@First_Name , Last_Name=@Last_Name , City=@City , State=@State , Country=@Country , Nationality=@Nationality where First_Name=@First_Name");
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@First_Name", textBox1.Text);
                    command.Parameters.AddWithValue("@Last_Name", textBox2.Text);
                    command.Parameters.AddWithValue("@City", textBox3.Text);
                    command.Parameters.AddWithValue("@State", textBox4.Text);
                    command.Parameters.AddWithValue("@Country", textBox5.Text);
                    command.Parameters.AddWithValue("@Nationality", textBox6.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");

                    connection.Close();



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //step 1 Create SQL Connection
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionstring;
            connection.Open();

            //step 2 Create sql command

            SqlCommand commands = new SqlCommand();
            commands.Connection = connection;

            // step 3 run quesries
            commands.CommandText = @"SELECT *FROM stdDB where First_Name='"+listBox1.Text+"'";
            SqlDataReader datareader = commands.ExecuteReader();

            while (datareader.Read())
            {

                textBox1.Text =datareader.GetValue(0).ToString();
                textBox2.Text = datareader.GetValue(1).ToString();
                textBox3.Text = datareader.GetValue(2).ToString();
                textBox4.Text = datareader.GetValue(3).ToString();
                textBox5.Text = datareader.GetValue(4).ToString();
                textBox6.Text = datareader.GetValue(5).ToString();
            }
        }
    }
    }

