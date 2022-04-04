using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
   public class FileModel
    {
        public string? fileName { get; set; }

        public string? sendName { get; set; }

        public string? wwid { get; set; }

        public string? Message { get; set; }

        public FileModel(Comments comments)
        {
            fileName = comments.Subject;
            sendName = comments.Name;
            wwid     = comments.WWid;
            Message = comments.Comment;
        }

        //public FileModel() { }
    }
}
