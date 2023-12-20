using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class QuizController:BaseApiController<QuizController>
    {
        public QuizController(ILogger<QuizController> logger) : base(logger)
        {
        }

        [HttpGet]
        public ActionResult<string> GetQuizzes()
        {
            return "fdesdf";
        }
    }
}