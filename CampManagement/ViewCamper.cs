using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
            LoadCamper();
        }

        private void LoadCamper()
        {
            var conn = DatabaseHelper.GetConnection();
            try
            {
                conn.Open();
                string query = "SELECT id, name, sex,age, birthdate, phone FROM camp.campers;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                CamperInfo.DataSource = table;

                CamperInfo.Columns["name"].HeaderText = "Camper Name";
                CamperInfo.Columns["age"].HeaderText = "Age";
                CamperInfo.Columns["sex"].HeaderText = "Sex";
                CamperInfo.Columns["birthdate"].HeaderText = "Birthdate";
                CamperInfo.Columns["phone"].HeaderText = "Phone Number";


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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UpdateCamper_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM campers", conn);
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(adapter);

                    DataTable table = (DataTable)CamperInfo.DataSource;
                    adapter.UpdateCommand = builder.GetUpdateCommand();
                    adapter.Update(table);

                    MessageBox.Show("Campers updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating campers: " + ex.Message);
                }
            }
        }

        private void DelCamper_Click(object sender, EventArgs e)
        {
            if (CamperInfo.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this camper?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int selectedRowIndex = CamperInfo.SelectedRows[0].Index;

                    int camperId = Convert.ToInt32(CamperInfo.Rows[selectedRowIndex].Cells["id"].Value);

                    using (MySqlConnection conn = DatabaseHelper.GetConnection())
                    {
                        try
                        {
                            conn.Open();

                            string query = "DELETE FROM campers WHERE id = @id";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", camperId);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Camper deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadCamper(); // Reload DataGridView
                                }
                                else
                                {
                                    MessageBox.Show("Delete failed. Camper not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error deleting camper: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SearchBar_TextChanged(object sender, EventArgs e)
        {
            string keyword = SearchBar.Text.Trim();
            SearchCampers(keyword);
        }

        private void SearchCampers(string keyword)
        {
            using (MySqlConnection conn = DatabaseHelper.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT * FROM campers 
                             WHERE name LIKE @keyword 
                                OR sex LIKE @keyword 
                                OR age LIKE @keyword";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        CamperInfo.DataSource = table;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching campers: " + ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadCamper();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddCamper addCamper = new AddCamper();
            addCamper.Show();
            LoadCamper();
        }
    }
}
