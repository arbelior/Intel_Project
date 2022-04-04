using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string? module { get; set; }
        public string? task { get; set; }
        public string? pM_Step { get; set; }
        public int? imageLocation { get; set; }
        public string? description { get; set; }
        public string? part { get; set; }
        public string? torque { get; set; }


        public ImageModel() { }

        public ImageModel(All_Images Img)
        {
            Id = Img.id;
            module = Img.Module;
            task = Img.Task;
            pM_Step = Img.PM_Step;
            imageLocation = Img.ImageLocation;
            description = Img.description;
            part = Img.part;
            torque = Img.Torque;
        }
    }
}
