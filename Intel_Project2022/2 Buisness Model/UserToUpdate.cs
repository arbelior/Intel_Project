using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
   public class UserToUpdate
    {
        public int id { get; set; }

        public string? First_name { get; set; }

        public string? Last_name { get; set; }

        public string? User_name { get; set; }

        public string? pass { get; set; }

        public string? Role { get; set; } = "User";

        public string? Jwt_token { get; set; }

        public UserToUpdate(UserModel user)
        {

        }
    }
}
