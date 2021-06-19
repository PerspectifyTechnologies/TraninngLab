using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingLab.Models
{
    public class QuestionnaireModel
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string QuestionText { get; set; }
        public List<string> OptionList { get; set; }
        public string TypeOfQuestion { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
