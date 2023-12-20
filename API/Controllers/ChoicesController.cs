using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers.Entities;
using API.Controllers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ChoicesController : BaseApiController<ChoicesController>
    {
        private IChoiceRepository _choiceRepository;

        public ChoicesController(ILogger<ChoicesController> logger,IChoiceRepository choiceRepository) : base(logger)
        {
            _choiceRepository = choiceRepository;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Choice>> GetChoice(long id)
        {
            var choice = await _choiceRepository.GetByIdAsync(id);

            if (choice == null)
            {
                return NotFound();
            }

            return choice;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Choice>>> GetChoices()
        {
            return Ok(await _choiceRepository.GetAllAsync());
        }
    }
}