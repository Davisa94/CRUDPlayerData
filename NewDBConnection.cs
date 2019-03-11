using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace WindowsFormsApp1
{
    class RemoteDBConnection
    {
        private string connectStringRemote = @"server=skycraftia.duckdns.org;user id=remote;password=remoteCanGetIn@126;persistsecurityinfo=True;database=PlayerTeamData";
        private string connectStringOld = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public int SavePlayer(Player player)
        {
            int lastId = -1;
            //Check if th emiddlename needs to be nulled
            string middleName = player.MiddleName;
            if (middleName == "") { middleName = "NULL"; }
            //Create connection string for local DB
            using (MySqlConnection connection = new MySqlConnection(this.connectStringRemote))
            {
                //Create the insertion query
                //TODO: is there a way to prepare this statment
                string query = "INSERT INTO PlayerTeamData.playerInfo (FirstName, MiddleName, LastName, DateOfBirth, HeightInches, JerseyNumber) " +
                    "VALUES (?firstName,?middleName, ?lastName, ?DOB, ?height, ?jerseyNum);" + "SELECT LAST_INSERT_ID();";
                //Prepare the query
                using (MySqlCommand command = new MySqlCommand(query))
                {
                    command.Connection = connection;
                    //Set the command type
                    command.CommandType = System.Data.CommandType.Text;
                    //Set the command text equal to the query:
                    command.CommandText = query;
                    //Prepare the variables:
                    command.Parameters.AddWithValue("?firstName", player.FirstName);
                    command.Parameters.AddWithValue("?middleName", player.MiddleName);
                    command.Parameters.AddWithValue("?lastName", player.LastName);
                    command.Parameters.AddWithValue("?DOB", player.DateOfBirth);
                    command.Parameters.AddWithValue("?height", player.HeightInches);
                    command.Parameters.AddWithValue("?jerseyNum", player.JerseyNum);

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
            string query = "Select Id FROM PlayerTeamData.Teams WHERE TeamName like '" + TeamName + "'";
            MySqlConnection connection = new MySqlConnection(this.connectStringRemote);
            MySqlCommand command = new MySqlCommand(query, connection);
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
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
            using (MySqlConnection connection = new MySqlConnection(this.connectStringRemote))
            {
                int totalRows = 0;
                //get Team Name:
                //Create the insertion query
                //TODO: is there a way to prepare this statment
                //LEFT OFF: Change sql to insert intoplayer to team 
                string query = "INSERT INTO PlayerTeamData.PlayerToTeam (player_id, team_id) " +
                    " VALUES (?playerId,?teamId)";
                //Prepare the query
                using (MySqlCommand command = new MySqlCommand(query))
                {
                    command.Connection = connection;
                    //Set the command type
                    command.CommandType = System.Data.CommandType.Text;
                    //Set the command text equal to the query:
                    command.CommandText = query;
                    //Prepare the variables:

                    command.Parameters.AddWithValue("?playerId", playerId);
                    command.Parameters.AddWithValue("?teamId", CurrentTeamId);
                    connection.Open();
                    totalRows = command.ExecuteNonQuery();
                    connection.Close();
                }
                //Insert the past teams:
                foreach (int teamId in PastTeamIds)
                {
                    using (MySqlConnection connection2 = new MySqlConnection(this.connectStringRemote))
                    {
                        //get Team Name:
                        //Create the insertion query
                        //TODO: is there a way to prepare this statment
                        //LEFT OFF: Change sql to insert intoplayer to team 
                        query = "INSERT INTO PlayerTeamData.PlayerToPastTeams (Player_id, Team_id) " +
                            " VALUES (?playerId,?teamId)";
                        //Prepare the query
                        using (MySqlCommand command = new MySqlCommand(query))
                        {
                            command.Connection = connection;
                            //Set the command type
                            command.CommandType = System.Data.CommandType.Text;
                            //Set the command text equal to the query:
                            command.CommandText = query;
                            //Prepare the variables:
                            command.Parameters.AddWithValue("?playerId", playerId);
                            command.Parameters.AddWithValue("?teamId", teamId);
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
            MySqlConnection connection = new MySqlConnection(this.connectStringRemote);
            DataTable dataTable = new DataTable();
            connection.Open();
            //Get player name
            string query = "Select * FROM PlayerTeamData.playerInfo";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
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

            MySqlConnection connection = new MySqlConnection(this.connectStringRemote);

            connection.Open();
            //BEGIN TODO:
            //Get Current Team
            //Add current team as a column
            //Add past Teams as a column
            //foreach past team add a row containing the column
            //END TODO;

            //Get player name
            string query = "Select FirstName, LastName FROM PlayerTeamData.playerInfo WHERE Id=" + id.ToString();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                PlayerName = reader["FirstName"].ToString();
                PlayerName += " ";
                PlayerName += reader["LastName"].ToString();
            }

            reader.Close();
            //Get the Current Team from the Database
            query = "SELECT TeamName FROM PlayerTeamData.Teams WHERE Id = (SELECT team_id FROM PlayerTeamData.PlayerToTeam WHERE player_id =" + id.ToString() + ");";
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                CurrentTeam = reader["TeamName"].ToString();
            }
            reader.Close();
            //Get a list of Past Teams ids from the Database and add them to rows
            query = "SELECT team_id FROM PlayerTeamData.PlayerToPastTeams WHERE player_id =" + id.ToString();
            command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                PastTeams.Add(Convert.ToInt32(reader["team_id"]));
            }
            reader.Close();
            //for each id query the db for its name and add a row for it
            foreach (int team_id in PastTeams)
            {
                query = "SELECT TeamName FROM PlayerTeamData.Teams WHERE Id =" + team_id.ToString();
                command = new MySqlCommand(query, connection);
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
            MySqlConnection connection = new MySqlConnection(this.connectStringRemote);
            connection.Open();
            string query = "Select TeamName FROM PlayerTeamData.Teams";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TeamNames.Add(reader["TeamName"].ToString());
            }
            connection.Close();
            return TeamNames;

        }
    }
}
