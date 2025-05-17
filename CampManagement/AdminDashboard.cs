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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            //LoadDataStaff();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = "SELECT total_campers, total_staff, total_programs, total_campsites FROM camp_summary";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Totalcamper.Text = reader["total_campers"].ToString();
                            Totalstaff.Text = reader["total_staff"].ToString();
                            Totalprog.Text = reader["total_programs"].ToString();
                            Totalsite.Text = reader["total_campsites"].ToString();
                        }
                    }

                    string query2 = "SELECT sex, COUNT(*) AS count FROM camp.campers GROUP BY sex;";
                    using (MySqlCommand cmd = new MySqlCommand(query2, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        int maleCount = 0;
                        int femaleCount = 0;

                        while (reader.Read())
                        {
                            string sex = reader["sex"].ToString();
                            int count = Convert.ToInt32(reader["count"]);

                            if (sex == "M")
                                maleCount = count;
                            else if (sex == "F")
                                femaleCount = count;
                        }

                        Malecount.Text = maleCount.ToString();
                        Femalecount.Text = femaleCount.ToString();

                    }

                    string query3 = "SELECT name AS 'Camper Name', age AS 'Age', sex AS 'Sex' FROM camp.campers";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query3, conn);

                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewCamper.DataSource = table;

                    string query4 = "SELECT staff_name AS 'Staff Name', role_name AS 'Designation' from camp.staff_user_info";
                    adapter = new MySqlDataAdapter(query4, conn);
                    DataTable table2 = new DataTable();
                    adapter.Fill(table2);
                    dataGridViewStaff.DataSource = table2;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading camp summary: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Totalcamper_Click(object sender, EventArgs e)
        {

        }

        private void Totalstaff_Click(object sender, EventArgs e)
        {

        }

        private void Totalprog_Click(object sender, EventArgs e)
        {

        }

        private void Totalsite_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Malecount_Click(object sender, EventArgs e)
        {
          
        }

        private void Femalecount_Click(object sender, EventArgs e)
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
            this.Hide();
            ViewStaff staff = new ViewStaff();
            staff.Show();
        }
    }
}
