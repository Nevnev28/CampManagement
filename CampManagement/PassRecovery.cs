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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CampManagement
{
    public partial class PassRecovery : Form
    {
        public PassRecovery()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
  

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string email = textBox1.Text.Trim();
            string securityAnswer = textBox2.Text.Trim();

            using (var conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE email = @Email AND security_answer = @SecurityAnswer";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@SecurityAnswer", securityAnswer);

                        int result = Convert.ToInt32(cmd.ExecuteScalar());

                        if (result > 0)
                        {
                            MessageBox.Show("Verification successful. Proceed to change password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ChangePass changeForm = new ChangePass(email); 
                            changeForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect email or answer to the security question.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database connection error: " + ex.Message);
                }
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //input for Email
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //input for security question
        }
    }
}
