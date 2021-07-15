using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UserServices.Models
{
    public class TestlevelModels
    {
        public int LevelID { get; set; }
        public string LevelName { get; set; }
        public bool HasTaken { get; set; }
        public bool NextInLine { get; set; }
    }
}
