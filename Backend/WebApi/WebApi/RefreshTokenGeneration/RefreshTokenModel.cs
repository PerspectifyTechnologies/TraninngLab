using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class RefreshTokenModel
    {
        public string Username { get; set; }
        public string RefreshToken { get; set; }
        public System.DateTime ExpirationTime { get; set; }
    }
}
