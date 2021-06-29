using System;

namespace WebApi.RefreshToken
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
