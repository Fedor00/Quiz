using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Entities;

namespace API.Entities
{
    public class Answer
{
    public long Id { get; set; }
    public long QuestionId { get; set; }
    public long CorrectChoiceId { get; set; }
    public Question Question { get; set; }
    public Choice CorrectChoice { get; set; }
}
}