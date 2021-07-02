using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.TestServices.Models
{
    public class QnAModel
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int Answer { get; set; }
    }
}
