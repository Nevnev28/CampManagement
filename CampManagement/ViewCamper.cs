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
    public partial class ViewCamper : Form
    {
        // Constructor definition
        public ViewCamper()
        {
            InitializeComponent();
        }

        private void ViewCamper_Load(object sender, EventArgs e)
        {
            //LoadDataStaff();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            var conn = DatabaseHelper.GetConnection();
            try
            {
                conn.Open();
                string query = "SELECT * from camp.staff";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            MessageBox.Show("Successfully logout");
            Login login = new Login();
            login.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewCamper viewCamper = new ViewCamper();
            viewCamper.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
        }
    }
}
