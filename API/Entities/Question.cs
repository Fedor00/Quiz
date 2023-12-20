using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Controllers.Entities
{
    public class Question
    {
        public long Id { get; set; }
        public long AnswerId { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public Answer Answer { get; set; }
        public IEnumerable<Choice> Choices { get; set; }
    }
}