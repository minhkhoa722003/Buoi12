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
namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        private const string connectionString = "Data Source=A209PC13;Initial Catalog=QLNET;Integrated Security=True";
        private SqlConnection connection;

        public MainForm()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load any initial data or perform other setup tasks
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                int age = int.Parse(txtAge.Text);

                string insertQuery = "INSERT INTO YourTable (Name, Age) VALUES (@Name, @Age)";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Record added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                string name = txtName.Text;
                int age = int.Parse(txtAge.Text);

                string updateQuery = "UPDATE YourTable SET Name = @Name, Age = @Age WHERE Id = @Id";
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                    MessageBox.Show("Record updated successfully.");
                else
                    MessageBox.Show("Record not found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);

                string deleteQuery = "DELETE FROM YourTable WHERE Id = @Id";
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                    MessageBox.Show("Record deleted successfully.");
                else
                    MessageBox.Show("Record not found.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
