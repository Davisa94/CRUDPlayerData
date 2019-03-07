using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void submitButton_Click(object sender, EventArgs e)
        {
            Player player = new Player();
            player.FirstName = firstNameTextBox.Text;
            player.MiddleName = middleNameTextBox.Text;
            player.LastName = lastNameTextBox.Text;
            player.JerseyNum = Convert.ToInt32(jerseyNumTextBox.Text);
            player.HeightInches = Convert.ToDecimal(heightTextBox.Text);
            player.DateOfBirth = Convert.ToDateTime(dateTimePicker1.Text);
            player.CurrentTeam = currentTeamComboBox.Text;

            //TODO: capture past teams form new input type
            //create a DBConnection and insert the player Data
            DBConnection dbo = new DBConnection();
            dbo.SavePlayer(player);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //create DB object
            DBConnection dbo = new DBConnection();
            //create the list
            List<string> CurrentTeamNames = new List<string>();
            List<string> PastTeamNames = new List<string>();

            CurrentTeamNames = dbo.GetTeams();
            PastTeamNames = CurrentTeamNames;

            this.currentTeamComboBox.DataSource = CurrentTeamNames;
            this.checkedListBox1.DataSource = PastTeamNames;
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
    }
}
