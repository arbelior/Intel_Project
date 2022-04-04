using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class ModuleModel
    {
        public int id { get; set; }
        public string? module { get; set; }
        public string? tool { get; set; }
        public int? gas_line { get; set; }
        public string? gas_name { get; set; }
        public int? lower_limit { get; set; }
        public int? target { get; set; }
        public int? upper_limit { get; set; }

        public ModuleModel(ModuleGasLimit Data_Modules)
        {
            id = Data_Modules.Id;
            module = Data_Modules.Module;
            tool = Data_Modules.Tool;
            gas_line = Data_Modules.GasLine;
            gas_name = Data_Modules.GasName;
            lower_limit = Data_Modules.LowerLimit;
            target = Data_Modules.Target;
            upper_limit = Data_Modules.UpperLimit;

        }



    }
}
