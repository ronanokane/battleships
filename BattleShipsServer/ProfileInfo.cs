using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShipsServer
{
    [Serializable]
    public struct ProfileInfo
    {
        public string Description;
        public int Age;
        public string Firstname;
        public string Surname;
        public string Username;
        public string Password;

        public ProfileInfo(string descrip, int age, string firstName, string surname, string username, string pass)
        {
            Description = descrip;
            Age = age;
            Firstname = firstName;
            Surname = surname;
            Username = username;
            Password = pass;
        }
    }
}
