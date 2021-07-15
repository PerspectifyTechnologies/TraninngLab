using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.TestServices.Model;

namespace WebApi.TestServices.Models
{
    public class QnAModel
    {
        public int QuesID { get; set; }
        public string Question { get; set; }
        public List<Option> Options { get; set; }
    }
}
