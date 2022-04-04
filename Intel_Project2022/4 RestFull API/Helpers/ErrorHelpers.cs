using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IntelPro
{
    public class ErrorHelpers
    {
        public static string GetExcepton(Exception ex)
        {

#if DEBUG
            return GetExtractMessage(ex);

#else
            return "Some error occured, please try again later.";
#endif

        }

        private static string GetExtractMessage(Exception ex)
        {
            if (ex.InnerException == null)
                return ex.Message;

            return GetExtractMessage(ex.InnerException);
        }
    }
}
