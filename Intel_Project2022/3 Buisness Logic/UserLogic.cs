using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class UserLogic : BaseLogic
    {
        public string Username;
        public string UserPass;

   
        public bool IsUserExisting(string UserName)
        {
            return DB.Access_Permission.Any(p => p.User_Name == UserName);
        }

        public UserModel UserIfloginToupdate_Token(string FirstName)
        {
            return DB.Access_Permission.Where(p => p.First_Name == FirstName).Select(p => new UserModel(p)).SingleOrDefault();
        }

        public List<UserModel> GetAllData()
        {
            return DB.Access_Permission.Select(p => new UserModel(p)).ToList();
        }


        public UserModel AddUser(UserModel New_User)
        {
            Access_Permission AddNew_User = New_User.ConvertToAccessModel();
            DB.Access_Permission.Add(AddNew_User);
            DB.SaveChanges();
            New_User.id = AddNew_User.Id;
            return New_User;
        }

        public UserModel GetUserbyCreditionals(Creditionals creditionals)
        {
            this.Username = creditionals.Username;
            this.UserPass = creditionals.Password;
            return DB.Access_Permission.Where(u => u.User_Name == creditionals.Username && u.Pass == creditionals.Password).Select(p => new UserModel(p)).SingleOrDefault();
        }

        public List<UserModel> UpdateTokenToUserIfLogin(UserModel UpdateUserJWT)
        {

            var UpdateResult = DB.Access_Permission.SingleOrDefault
                (p => p.User_Name == UpdateUserJWT.User_name && p.Pass == UpdateUserJWT.pass);
            UpdateResult.Jwt_Token = UpdateUserJWT.Jwt_token;
            DB.SaveChanges();
            return DB.Access_Permission.Select(p => new UserModel(p)).ToList();

        }

    }

}
