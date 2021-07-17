using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.AuthServices.Models
{
    public class UserPayload
    {
        public string Username { get; set; }
        public string Payload { get; set; }
    }
}
