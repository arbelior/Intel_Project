using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelPro
{
    public abstract class BaseLogic : IDisposable
    {
        protected MyDataBaseContext DB;

        public BaseLogic()
        {
            DB = new MyDataBaseContext();
        }

        public void Dispose()
        {
            //Aviad: I have nothing to close here.
        }
    }
}
