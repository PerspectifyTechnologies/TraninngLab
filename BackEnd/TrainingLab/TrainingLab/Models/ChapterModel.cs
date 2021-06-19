using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingLab.Models
{
    public class ChapterModel
    {
        public int Id { get; set; }
        public string ChapterName { get; set; }
        public List<string> Topics { get; set; }
        public string VideoURL { get; set; }
        public string NotesURL { get; set; }
    }
}
