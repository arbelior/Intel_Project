using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class ToolsPerTool
    {
        public int gasline { get; set; }
        public string gasname { get; set; }
        public int upper_limit { get; set; }
        public int lower_limit { get; set; }
        public int target { get; set; }




        public ToolsPerTool(ModuleGasLimit Tool)
        {
            gasname = Tool.GasName;
            gasline = Tool.GasLine;
            upper_limit = Tool.UpperLimit;
            lower_limit = Tool.LowerLimit;
            target = Tool.Target;

        }
    }
}
