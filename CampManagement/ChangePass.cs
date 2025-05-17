using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CampManagement
{
    public partial class ChangePass : Form
    {
        private string userEmail;

        public ChangePass(string email)
        {
            
            InitializeComponent();
            userEmail = email;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter a new password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("ChangeUserPassword", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Assuming stored procedure parameters
                        cmd.Parameters.AddWithValue("@user_email", userEmail);
                        cmd.Parameters.AddWithValue("@new_password", newPassword);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Password successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide(); 

                        Login loginForm = new Login();
                        loginForm.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
