using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingLab.Models
{
    public class UserScore
    {
        public int Id { get; set; }
        public float Score { get; set; }
        public string EmailId { get; set; }
        public int TestId { get; set; }

    }
}
