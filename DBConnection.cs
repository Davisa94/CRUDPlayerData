using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    class DBConnection
    {
        private string connectStringOld = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private string connectString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PlayerTeamData.mdf;Integrated Security=True";
        public int SavePlayer(Player player)
        {
            int lastId = -1;
            //Check if th emiddlename needs to be nulled
            string middleName = player.MiddleName;
            if (middleName == "") { middleName = "NULL"; }
            //Create connection string for local DB
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                //Create the insertion query
                //TODO: is there a way to prepare this statment
                string query = "INSERT INTO PlayerTeamData.dbo.playerInfo (FirstName, MiddleName, LastName, DateOfBirth, HeightInches, JerseyNumber) " +
                    "OUTPUT INSERTED.ID" +
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
                    //lastId = command.ExecuteNonQuery();
                    lastId = Convert.ToInt32(command.ExecuteScalar());
                    connection.Close();
                    //get last insert id:

                }
            }  
            return lastId;
        }

        public int GetTeamId(string TeamName)
        {
            int id = 0;
            string query = "Select Id FROM PlayerTeamData.dbo.Teams WHERE TeamName like '" + TeamName + "'";
            SqlConnection connection = new SqlConnection(this.connectString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["Id"]);
            }
            connection.Close();
            return id;
        }
        // Adds the given player to its teams past and present
        public int AddPlayerToTeams(Player player, int playerId)
        {
            //Add player to current team:
            int CurrentTeamId = this.GetTeamId(player.CurrentTeam);
            List<int> PastTeamIds = new List<int>();
            //For each past team in the list do stuff:
            foreach (string TeamName in player.PastTeams)
            {
                PastTeamIds.Add(this.GetTeamId(TeamName));

            }
            //Insert the Current Team
            using (SqlConnection connection = new SqlConnection(this.connectString))
            {
                int totalRows = 0;
                //get Team Name:
                //Create the insertion query
                //TODO: is there a way to prepare this statment
                //LEFT OFF: Change sql to insert intoplayer to team 
                string query = "INSERT INTO PlayerTeamData.dbo.PlayerToTeam (player_id, team_id) " +
                    " VALUES (@playerId,@teamId)";
                //Prepare the query
                using (SqlCommand command = new SqlCommand(query))
                {
                    command.Connection = connection;
                    //Set the command type
                    command.CommandType = System.Data.CommandType.Text;
                    //Set the command text equal to the query:
                    command.CommandText = query;
                    //Prepare the variables:
                    
                    command.Parameters.AddWithValue("@playerId", playerId);
                    command.Parameters.AddWithValue("@teamId", CurrentTeamId);
                    connection.Open();
                    totalRows = command.ExecuteNonQuery();
                    connection.Close();
                }
                //Insert the past teams:
                foreach (int teamId in PastTeamIds)
                {
                    using (SqlConnection connection2 = new SqlConnection(this.connectString))
                    {
                        //get Team Name:
                        //Create the insertion query
                        //TODO: is there a way to prepare this statment
                        //LEFT OFF: Change sql to insert intoplayer to team 
                        query = "INSERT INTO PlayerTeamData.dbo.PlayerToPastTeams (Player_id, Team_id) " +
                            " VALUES (@playerId,@teamId)";
                        //Prepare the query
                        using (SqlCommand command = new SqlCommand(query))
                        {
                            command.Connection = connection;
                            //Set the command type
                            command.CommandType = System.Data.CommandType.Text;
                            //Set the command text equal to the query:
                            command.CommandText = query;
                            //Prepare the variables:
                            command.Parameters.AddWithValue("@playerId", playerId);
                            command.Parameters.AddWithValue("@teamId", teamId);
                            connection.Open();
                            totalRows += command.ExecuteNonQuery();
                            connection.Close();
                        }
                        //TODO: add try catch:

                    }
                }
                    
                return totalRows;
            }
        }

        public DataTable GetPlayersInfo()
        {
            SqlConnection connection = new SqlConnection(this.connectString);
            DataTable dataTable = new DataTable();
            connection.Open();
            //Get player name
            string query = "Select * FROM PlayerTeamData.dbo.playerInfo";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            connection.Close();
            dataAdapter.Dispose();
            return dataTable;
        }
        public DataTable GetPlayerTeamInfo(int id)
        {
            //create list to store team names:
            bool init = false;
            string PlayerName = "";
            string CurrentTeam = "";
            List<int> PastTeams = new List<int>();
            DataTable PlayerTeamInfo = new DataTable("PlayerTeamInfo");
            PlayerTeamInfo.Columns.Add(new DataColumn("PlayerName", typeof(string)));
            PlayerTeamInfo.Columns.Add(new DataColumn("CurrentTeam", typeof(string)));
            PlayerTeamInfo.Columns.Add(new DataColumn("PastTeams", typeof(string)));
            DataRow initRow = PlayerTeamInfo.NewRow();

            SqlConnection connection = new SqlConnection(this.connectString);

            connection.Open();
            //BEGIN TODO:
            //Get Current Team
            //Add current team as a column
            //Add past Teams as a column
            //foreach past team add a row containing the column
            //END TODO;

            //Get player name
            string query = "Select FirstName, LastName FROM PlayerTeamData.dbo.playerInfo WHERE Id=" + id.ToString();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PlayerName = reader["FirstName"].ToString();
                PlayerName += " ";
                PlayerName += reader["LastName"].ToString();
            }
            
            reader.Close();
            //Get the Current Team from the Database
            query = "SELECT TeamName FROM PlayerTeamData.dbo.Teams WHERE Id = (SELECT team_id FROM PlayerTeamData.dbo.PlayerToTeam WHERE player_id =" + id.ToString() +");"; 
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                CurrentTeam = reader["TeamName"].ToString();
            }
            reader.Close();
            //Get a list of Past Teams ids from the Database and add them to rows
            query = "SELECT team_id FROM PlayerTeamData.dbo.PlayerToPastTeams WHERE player_id =" + id.ToString();
            command = new SqlCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                PastTeams.Add(Convert.ToInt32(reader["team_id"]));
            }
            reader.Close();
            //for each id query the db for its name and add a row for it
            foreach (int team_id in PastTeams)
            {
                query = "SELECT TeamName FROM PlayerTeamData.dbo.Teams WHERE Id =" + team_id.ToString();
                command = new SqlCommand(query, connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (init == false)
                    {
                        initRow["PlayerName"] = PlayerName;
                        initRow["CurrentTeam"] = CurrentTeam;
                        initRow["PastTeams"] = reader["TeamName"].ToString();
                        PlayerTeamInfo.Rows.Add(initRow);
                        init = true;
                    }
                    else
                    {
                        DataRow row = PlayerTeamInfo.NewRow();
                        row["PastTeams"] = reader["TeamName"].ToString();
                        PlayerTeamInfo.Rows.Add(row);
                    }
                    
                }
                reader.Close();
            }


            connection.Close();
            return PlayerTeamInfo;

        }
        public List<string> GetTeams()
        {
            //create list to store team names:
            List<string> TeamNames = new List<string>();
            SqlConnection connection = new SqlConnection(this.connectString);
            connection.Open();
            string query = "Select TeamName FROM PlayerTeamData.dbo.Teams";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TeamNames.Add(reader["TeamName"].ToString());
            }
            connection.Close();
            return TeamNames;

        }
    }
}
