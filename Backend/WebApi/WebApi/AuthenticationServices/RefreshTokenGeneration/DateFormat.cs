using System;

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
