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
            LoadStaff();
        }

        private void LoadStaff()
        {
            var conn = DatabaseHelper.GetConnection();
            try
            {
                conn.Open();
                string query = "SELECT id, user_id, role_id, name, phone FROM camp.staff;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                StaffInfo.DataSource = table;

                StaffInfo.Columns["id"].HeaderText = "ID";
                StaffInfo.Columns["user_id"].HeaderText = "User ID";
                StaffInfo.Columns["role_id"].HeaderText = "Role ID";
                StaffInfo.Columns["name"].HeaderText = "Staff Name";
                StaffInfo.Columns["phone"].HeaderText = "Phone Number";

                string query1 = "SELECT id, name FROM camp.roles;";
                MySqlDataAdapter adapter1 = new MySqlDataAdapter(query1, conn);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                StaffRole.DataSource = table1;

                StaffRole.Columns["id"].HeaderText = "ID";
                StaffRole.Columns["name"].HeaderText = "Designation";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

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
            ViewStaff viewStaff = new ViewStaff();
            viewStaff.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
        }

        private void CamperInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadStaff();
        }

        private void UpdateCamper_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM staff", conn);
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    DataTable table = (DataTable)StaffInfo.DataSource;
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    adapter.Update(table);

                    MessageBox.Show("Staff updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating staff: " + ex.Message);
                }
            }
        }

        private void DelCamper_Click(object sender, EventArgs e)
        {
            if (StaffInfo.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this staff?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int selectedRowIndex = StaffInfo.SelectedRows[0].Index;

                    int staffId = Convert.ToInt32(StaffInfo.Rows[selectedRowIndex].Cells["id"].Value);

                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        try
                        {
                            conn.Open();

                            string query = "DELETE FROM camp.staff WHERE id = @id";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", staffId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Staff deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadStaff(); // Reload DataGridView
                                }
                                else
                                {
                                    MessageBox.Show("Delete failed. Staff not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting Staff: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
