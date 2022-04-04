using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelPro.Helpers
{
    public interface IJwtHelper
    {
        string GetToken(string username);
    }
}
