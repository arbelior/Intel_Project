using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class Torque_ListModel
    {
        public int Id { get; set; }

        public string? Module { get; set; }

        public string? Part { get; set; }

        public string? Torque { get; set; }

        public string? Route { get; set; }

        public string? Chambar { get; set; }

        public string? PM { get; set; }


        public Torque_ListModel() { }

        public Torque_ListModel(Torque_List torque)
        {
            Id = torque.id;
            Module = torque.Module;
            Part = torque.Part;
            Torque = torque.Torque;
            Route = torque.Route;
            Chambar = torque.Chambar;
            PM = torque.pm;
        }

        public Torque_List ConvertToTorqueModel()
        {
            Torque_List Add_Value_Torque = new Torque_List
            {
                id = Id,
                Module = Module,
                Part = Part,
                Torque = Torque,
                Route = Route,
                Chambar = Chambar,
                pm = PM
            };
            return Add_Value_Torque;

        }
    }
}
