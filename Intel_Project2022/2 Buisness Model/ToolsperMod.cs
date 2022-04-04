using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class ToolsperMod
    {
        public string tool { get; set; }

        public ToolsperMod(ModuleGasLimit Mod)
        {
            tool = Mod.Tool;


        }




    }



}
