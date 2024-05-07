using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUDWEB
{
    public partial class _Default : Page
    {
        string connectionString = "Data Source = DESKTOP-FTIBSHC\\SQLEXPRESS; Initial " +
                "Catalog=comp;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            

            ////Establish a connection to the SQL Server database
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();


            //    DataSet dataSet = new DataSet();
            //    using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Product", connection))
            //    {
            //        adapter.Fill(dataSet, "Product");
            //    }


            //    DataTable dataTable = dataSet.Tables["Product"];
            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        TextBox1.Text =Convert.ToString(row["ID"]);
            //        TextBox2.Text =Convert.ToString(row["Name"]);
            //    }
            //    connection.Close();
            //}
        }

        public void readData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                DataSet dataSet = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Product", connection))
                {
                    adapter.Fill(dataSet, "Product");
                }


                DataTable dataTable = dataSet.Tables["Product"];
                foreach (DataRow row in dataTable.Rows)
                {
                    TextBox1.Text =Convert.ToString(row["ID"]);
                    TextBox2.Text =Convert.ToString(row["Name"]);
                }
                connection.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            

        }

        protected void Read_Click(object sender, EventArgs e)
        {
            readData();

        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source = DESKTOP-FTIBSHC\\SQLEXPRESS; Initial " +
           "Catalog=comp;Integrated Security=True";

            //Establish a connection to the SQL Server database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand insertCommand = new SqlCommand("INSERT INTO Product (ID, Name) Values (@ID, @Name)", connection);
                insertCommand.Parameters.AddWithValue("@ID", TextBox1.Text);
                insertCommand.Parameters.AddWithValue("@Name", TextBox2.Text);
                int rowsAffected = insertCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Label1.Text = "Data is Inserted";
                    TextBox1.Text="";
                    TextBox2.Text="";
                }
                else
                {
                    Label1.Text="Data is not Inserted";
                }
                connection.Close();

            }

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand updateCommand = new SqlCommand("UPDATE Product SET Name = @Name WHERE ID = @ID", connection);
                updateCommand.Parameters.AddWithValue("@ID", TextBox1.Text);
                updateCommand.Parameters.AddWithValue("@Name", TextBox2.Text);
                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Label1.Text = "Record updated successfully";
                    TextBox1.Text="";
                    TextBox2.Text="";
                }
                else
                {
                    Label1.Text="Failed to update record!";
                }
                connection.Close();

            }

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand deleteCommand = new SqlCommand("DELETE FROM Product WHERE ID = @ID", connection);
                deleteCommand.Parameters.AddWithValue("@ID", TextBox1.Text);
                //updateCommand.Parameters.AddWithValue("@Name", TextBox2.Text);
                int rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Label1.Text = "Record deleted successfully";
                    TextBox1.Text="";
                    TextBox2.Text="";
                }
                else
                {
                    Label1.Text="No record found to delete!";
                }
                connection.Close();

            }

        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            TextBox1.Text="";
            TextBox2.Text="";
        }
    }
}