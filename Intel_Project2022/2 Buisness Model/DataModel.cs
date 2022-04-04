using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class DataModel
    {
        public int id { get; set; }
        public string? Techname { get; set; }
        public string? buddy { get; set; }
        public string? task { get; set; }
        public string? time { get; set; }
        public string? shift { get; set; }

        public DataModel() { }

        public DataModel(GlUpdatedPassdown data)
        {
            id = data.Id;
            Techname = data.Techname;
            buddy = data.Buddy;
            task = data.Task;
            time = data.Time;
            shift = data.Shift;
        }

        public GlUpdatedPassdown ConvertToModel()
        {
            GlUpdatedPassdown NewTask = new GlUpdatedPassdown
            {
                Id = id,
                Techname = Techname,
                Buddy = buddy,
                Task = task,
                Time = time,
                Shift = shift


            };

            return NewTask;
        }



    }
}

