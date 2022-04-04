using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class UserContactModel
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public DateTime? Date { get; set; }


        public UserContactModel() { }

        public UserContactModel(Contacts_Online contacts)
        {
            id = contacts.Id;
            Name = contacts.UserOnline;
            Type = contacts.Type;
            Date = contacts.date;
        }

        public Contacts_Online ConvertToModelUser()
        {
            Contacts_Online NewUser = new Contacts_Online
            {
                Id = id,
                UserOnline = Name,
                Type = Type,
                date = Date
            };

            return NewUser;
        }
    }
}
