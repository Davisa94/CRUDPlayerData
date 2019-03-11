using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //TODO Initialize Gridview1
            //TODO Initialize Gridview1
            RemoteDBConnection dbo = new RemoteDBConnection();
            dataGridView1.DataSource = dbo.GetPlayersInfo();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void ReloadTeamInfo()
        {
            RemoteDBConnection dbo = new RemoteDBConnection();
            //create the list
            List<string> CurrentTeamNames = new List<string>();
            List<string> PastTeamNames = new List<string>();
            try
            {
                CurrentTeamNames = dbo.GetTeams();
                PastTeamNames = dbo.GetTeams();
                this.currentTeamComboBox.DataSource = CurrentTeamNames;
                this.checkedListBox1.DataSource = PastTeamNames;
            }
            catch
            {
                MessageBox.Show("Couldnt connect to database");
            }
        }
        private void submitButton_Click(object sender, EventArgs e)
        {
            ReloadTeamInfo();
            Validation validator = new Validation();
            bool validInfo = false;
            bool validFirstName = false;
            bool validMiddleName = false;
            bool validLastName = false;
            bool validJerseyNum = false;
            bool validHeight = false;
            string message = "Please Check the following fields:\n";
            
            //validate:
            //validate names:
            Player player = new Player();
            if (firstNameTextBox.Text != "")
            {
                player.FirstName = firstNameTextBox.Text;
            }
            else
            {
                message += "No first name entered\n\n";
            }
            if (middleNameTextBox.Text != "")
            {
                player.MiddleName = middleNameTextBox.Text;
            }
            else
            {
                message += "No middle name entered\n\n";
            }
            if (lastNameTextBox.Text != "")
            {
                player.LastName = lastNameTextBox.Text;
            }
            else
            {
                message += "No last name entered\n\n";
            }
            if (jerseyNumTextBox.Text != "")
            {
                player.JerseyNum = Convert.ToInt32(jerseyNumTextBox.Text);

            }
            else
            {
                player.JerseyNum = -1;
                message += "No Jersey Number Entered\n\n";
            }
            if (heightTextBox.Text != "")
            {
                player.HeightInches = Convert.ToDecimal(heightTextBox.Text);
            }
            else
            {
                message += "No Height Entered\n\n";
                player.HeightInches = -1;
            }
            if (jerseyNumTextBox.Text != "")
            {
                player.DateOfBirth = Convert.ToDateTime(dateTimePicker1.Text);
            }
            if (currentTeamComboBox.Text != "")
            {
                player.CurrentTeam = currentTeamComboBox.Text;
            }
            else
                message += "Please enter A current team\n\n";
            
            //validate
            validFirstName = validator.ValidateName(player.FirstName);
            validMiddleName = validator.ValidateName(player.MiddleName);
            validLastName = validator.ValidateName(player.LastName);
            validJerseyNum = validator.ValidateWholeNumber(player.JerseyNum.ToString());
            validHeight = false;
            if (validator.ValidateDecimalNumbers(player.HeightInches.ToString()) || validator.ValidateWholeNumber(player.HeightInches.ToString()))
            {
                validHeight = true;
            }

            if (!validFirstName)
            {
                message += "Invalid First name, only letters are allowed; No spaces \n\n";
            }
            if (!validMiddleName)
            {
                message += "Invalid Middle name, only letters are allowed; No spaces\n\n";
            }
            if (!validLastName)
            {
                message += "Invalid Last name, only letters are allowed; No spaces\n\n";
            }
            if (!validJerseyNum)
            {
                message += "Invalid Jersey number, must be two numeric digits; No Spaces\n\n";
            }
            if (!validHeight)
            {
                message += "Invalid Height, must be the value in inches (two numeric digits)\n\tOptionaly followed by a decimal and numeric digits; No Spaces\n\n";
            }
            if (validFirstName && validMiddleName && validLastName && validJerseyNum && validHeight)
            {
                validInfo = true;
            }
            //Capture each team that was checked
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                player.PastTeams.Add(itemChecked.ToString());
                if (itemChecked.ToString() == player.CurrentTeam)
                {
                    message += "Cannot choose a team as both past and current: " + player.CurrentTeam + " \n\n";
                    validInfo = false;
                }
            }
            if (validInfo)
            {

                
                //create a DBConnection and insert the player Data
                RemoteDBConnection dbo = new RemoteDBConnection();
                int lastInsertId = dbo.SavePlayer(player);
                //TODO add player to teams past and present;
                dbo.AddPlayerToTeams(player, lastInsertId);
                MessageBox.Show("Thank you for your input");
                //TODO CLEAR EACH CONTROL
                firstNameTextBox.Text = "";
                middleNameTextBox.Text = "";
                lastNameTextBox.Text = "";
                jerseyNumTextBox.Text = "";
                heightTextBox.Text = "";
                dateTimePicker1.Value = Convert.ToDateTime("6/15/1994");
                currentTeamComboBox.SelectedIndex = -1;
                foreach (int index in checkedListBox1.CheckedIndices)
                {
                    checkedListBox1.SetItemCheckState(index, CheckState.Unchecked);
                }

                //this should redraw after submit:

                dataGridView1.DataSource = dbo.GetPlayersInfo();
            }
            else
                MessageBox.Show(message);
           
            

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'playerTeamDataDataSet.playerInfo' table. You can move, or remove it, as needed.
           
            //TODO: LOAD PLAYER LIST BY DEFAULT;
            //create DB object
            RemoteDBConnection dbo = new RemoteDBConnection();
            //create the list
            List<string> CurrentTeamNames = new List<string>();
            List<string> PastTeamNames = new List<string>();
            try
            {
                CurrentTeamNames = dbo.GetTeams();
                PastTeamNames = dbo.GetTeams();
                this.currentTeamComboBox.DataSource = CurrentTeamNames;
                this.checkedListBox1.DataSource = PastTeamNames;
            }
            catch
            {
                MessageBox.Show("Couldnt connect to database");
            }
            
            
        }

        private bool CheckIfDatabaseExists()
        {
            SqlConnection connection = new SqlConnection(@"Data Source =.\sqlexpress'Initial Catalog=Collage; Integrated Security=False");
            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void GenerateDatabase()
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pastTeamTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pastTeamTextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            RemoteDBConnection dbo = new RemoteDBConnection();
            
            DataTable PlayerTeamInfo = new DataTable();

            this.dataGridView2.DataSource = dbo.GetPlayerTeamInfo(value);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void heightTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
