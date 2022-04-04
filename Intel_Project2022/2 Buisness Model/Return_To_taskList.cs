using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class Return_To_taskList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string task { get; set; }
        public string router { get; set; }
        public string date { get; set; }

        public Return_To_taskList() { }

        public Return_To_taskList(Resume Add_Task_ToSave)
        {
            id = Add_Task_ToSave.Id;
            name = Add_Task_ToSave.Name;
            task = Add_Task_ToSave.Task;
            router = Add_Task_ToSave.Router;
            date = Add_Task_ToSave.Date;
        }

        public Resume ConvertToResumeModel()
        {
            Resume Add_Save = new Resume
            {
                Id = id,
                Name = name,
                Task = task,
                Router = router,
                Date = date

            };

            return Add_Save;


        }



    }

}


