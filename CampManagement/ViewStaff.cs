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
    public partial class ViewStaff : Form
    {
        // Constructor definition
        public ViewStaff()
        {
            InitializeComponent();
        }

        private void ViewStaff_Load(object sender, EventArgs e)
        {
            //LoadDataStaff();
            LoadDashboard();
        }

        private void LoadDashboard()
        {
          
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
        }
    }
}
