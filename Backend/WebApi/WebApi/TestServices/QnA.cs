using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.TestServices
{
    public class QnA
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
        public int Answer { get; set; }
    }
}
