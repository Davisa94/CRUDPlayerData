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

            //Capture each team that was checked
            foreach(object itemChecked in checkedListBox1.CheckedItems)
            {
                player.PastTeams.Add(itemChecked.ToString());
            }
            //create a DBConnection and insert the player Data
            DBConnection dbo = new DBConnection();
            int lastInsertId = dbo.SavePlayer(player);
            //TODO add player to teams past and present;
            //dbo.AddPlayerToTeams(player, lastInsertId);
            MessageBox.Show("Thank you for your input");
            //TODO CLEAR EACH CONTROL
            //TODO UPDATE THE GRID VIEW WITH NEW ENTRY

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'playerTeamDataDataSet.playerInfo' table. You can move, or remove it, as needed.
            this.playerInfoTableAdapter.Fill(this.playerTeamDataDataSet.playerInfo);
            //TODO: LOAD PLAYER LIST BY DEFAULT;
            //create DB object
            DBConnection dbo = new DBConnection();
            //create the list
            List<string> CurrentTeamNames = new List<string>();
            List<string> PastTeamNames = new List<string>();

            CurrentTeamNames = dbo.GetTeams();  
            PastTeamNames = dbo.GetTeams();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int value = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            DBConnection dbo = new DBConnection();
            MessageBox.Show(value.ToString());
            DataTable PlayerTeamInfo = new DataTable();

            this.dataGridView2.DataSource = dbo.getPlayerTeamInfo(value);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
