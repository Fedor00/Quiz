using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.Entities
{
    public class Choice
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public string  Text { get; set; }
        public Question Question { get; set; }

    }
}