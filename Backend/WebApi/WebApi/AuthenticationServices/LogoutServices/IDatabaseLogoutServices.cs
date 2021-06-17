using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DatabaseServices
{
    interface IDatabaseLogoutServices
    {
        public void Logout(string username,string accessToken);
    }
}
