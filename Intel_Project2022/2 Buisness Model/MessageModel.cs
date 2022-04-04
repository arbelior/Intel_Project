using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class MessageModel
    {
        public int Id { get; set; }

        public string? Message { get; set; }

        public string? Name { get; set; }

        public string? Date { get; set; }

        public string? Shift { get; set; }

        public DateTime? Send_date { get; set; }

        public int? Day { get; set; }



        public MessageModel() { }

        public MessageModel(chat Messagedetailes)
        {
            Id            = Messagedetailes.id;
            Message       = Messagedetailes.message;
            Name          = Messagedetailes.Name;
            Date          = Messagedetailes.date;
            Shift         = Messagedetailes.Shift;
            Send_date     = Messagedetailes.activedate;
            Day           = Messagedetailes.day;
        }

        public chat ConvertToModel()
        {
            chat NewMessage = new chat
            {
                id         = Id,
                message    = Message,
                Name       = Name,
                date       = Date,
                Shift      = Shift,
                activedate = Send_date,
                day        = Day


                
            };
            return NewMessage;
        }
    }
}
