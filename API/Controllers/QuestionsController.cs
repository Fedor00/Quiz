using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Entities;
using API.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class QuestionsController:BaseApiController<QuestionsController>
    {
        private IQuestionRepository _questionRepository;

        public QuestionsController(ILogger<QuestionsController> logger,IQuestionRepository questionRepository) : base(logger)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var questions = await _questionRepository.GetAllAsync();
            return Ok(questions);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(long id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }
    }
}