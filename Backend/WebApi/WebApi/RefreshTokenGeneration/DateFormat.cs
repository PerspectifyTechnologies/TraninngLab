using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.RefreshTokenGeneration
{
    public class DateFormat
    {
        internal DateTime ConvertToSTDDateTime(string value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch (FormatException)
            {
                throw new Exception(message: "no value");
            }
        }
    }
}
