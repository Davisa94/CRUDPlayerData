using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DBConnection
    {
        private string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int SavePlayer(Player player)
        {
            int numRecords = -1;
            //Check if th emiddlename needs to be nulled
            string middleName = player.MiddleName;
            if (middleName == "") { middleName = "NULL"; }
            //Create connection string for local DB
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                //Create the insertion query
                //TODO: is there a way to prepare this statment
                string query = "INSERT INTO PlayerTeamData.dbo.playerInfo (FirstName, MiddleName, LastName, DateOfBirth, HeightInches, JerseyNumber) " +
                    " VALUES (@firstName,@middleName, @lastName, @DOB, @height, @jerseyNum)";
                //Prepare the query
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Connection = connection;
                    //Set the command type
                    command.CommandType = System.Data.CommandType.Text;
                    //Set the command text equal to the query:
                    command.CommandText = query;
                    //Prepare the variables:
                    command.Parameters.AddWithValue("@firstName", player.FirstName);
                    command.Parameters.AddWithValue("@middleName", player.MiddleName);
                    command.Parameters.AddWithValue("@lastName", player.LastName);
                    command.Parameters.AddWithValue("@DOB", player.DateOfBirth);
                    command.Parameters.AddWithValue("@height", player.HeightInches);
                    command.Parameters.AddWithValue("@jerseyNum", player.JerseyNum);

                    //TODO: add try catch:
                    connection.Open();
                    numRecords = command.ExecuteNonQuery();
                    connection.Close();


                }
            }  
            return numRecords;
        }
        public List<string> AddPlayerToTeam(Player player, int player_id)
        {
            //create list to store team names:
            List<string> TeamNames = new List<string>();
            //TODO: FIX CODE HERE
            return TeamNames;
        }
        public DataSet getPlayerInfo(int id)
        {
            //create list to store team names:
            DataSet PlayerInfo = new DataSet();
            SqlConnection connection = new SqlConnection(this.connectString);
            connection.Open();
            string query = "Select * FROM PlayerTeamData.dbo.PlayerToTeam";
            SqlCommand commmand = new SqlCommand(query, connection);
            SqlDataReader reader = commmand.ExecuteReader();
            while (reader.Read())
            {
                TeamNames.Add(reader["TeamName"].ToString());
            }
            return TeamNames;
        }
        public List<string> GetTeams()
        {
            //create list to store team names:
            List<string> TeamNames = new List<string>();
            SqlConnection connection = new SqlConnection(this.connectString);
            connection.Open();
            string query = "Select TeamName FROM PlayerTeamData.dbo.Teams";
            SqlCommand commmand = new SqlCommand(query, connection);
            SqlDataReader reader = commmand.ExecuteReader();
            while (reader.Read())
            {
                TeamNames.Add(reader["TeamName"].ToString());
            }
            return TeamNames;
        }
    }
}
