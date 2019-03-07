using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DBConnection
    {
        public bool SavePlayer(Player player)
        {
            //Create connection string for local DB
            string connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //Use connection string to make a connection to the DB
            SqlConnection connection = new SqlConnection(connectString);
            //Open the connection
            connection.Open();
            //Check if th emiddlename needs to be nulled
            string middleName = player.MiddleName;
            if(middleName == "") { middleName = "NULL"; }
            //Create the insertion query
            //TODO: is there a way to prepare this statment
            string query = "INSERT INTO PlayerTeamData.dbo.playerInfo (FirstName, MiddleName, LastName, DateOfBirth, HeightInches, JerseyNumber) " +
                " VALUES (@firstName,@middleName+, @lastName, @DOB, @height, @jerseyNum)";
            //Prepare the query
            using (SqlCommand querySavePlayer = new SqlCommand(query))
            {
                querySavePlayer.Connection = connection;
            }
                //Create the command using the query and the connection
                SqlCommand command = new SqlCommand(query, connection);
            //execute the command
            command.ExecuteNonQuery();

            connection.Close();
            return true;
        }
    }
}
