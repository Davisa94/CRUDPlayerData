﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Player
    {
        public int Id { get; set; }
        public int DateOfBirth { get; set; }
        public int JerseyNum { get; set; }
        public int HeightInches { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // a list of the past teams by name
        public string[] PastTeams { get; set; }
        public string CurrentTeam { get; set; }


    }
}