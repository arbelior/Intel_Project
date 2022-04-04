using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public class ModulesPerMod
    {
        public string module { get; set; }

        public ModulesPerMod(ModuleGasLimit Mod)
        {
            module = Mod.Module;


        }
    }
}
