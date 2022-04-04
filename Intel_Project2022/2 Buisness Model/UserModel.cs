using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace IntelPro
{
    public class UserModel
    {


        public int id { get; set; }

        public string? First_name { get; set; }

        public string? Last_name { get; set; }

        public string? User_name { get; set; }

        public string? pass { get; set; }

        public string? Role { get; set; } = "User";

        public string? Jwt_token { get; set; }

        public string? _command { get; set; }

        public UserModel() { }



        public UserModel(Access_Permission UsersData)
        {
            id = UsersData.Id;
            First_name = UsersData.First_Name;
            Last_name = UsersData.Last_Name;
            User_name = UsersData.User_Name;
            pass = UsersData.Pass;
            Role = UsersData.role;
            Jwt_token = UsersData.Jwt_Token;
            _command = UsersData.command;

        }

        public Access_Permission ConvertToAccessModel()
        {
            Access_Permission Add_User = new Access_Permission
            {
                Id = id,
                First_Name = First_name,
                Last_Name = Last_name,
                User_Name = User_name,
                Pass = pass,
                role = Role,
                Jwt_Token = Jwt_token,
                command = _command
            };

            return Add_User;
        }



    }
}
