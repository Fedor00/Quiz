using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ChoiceController : BaseApiController<ChoiceController>
    {
        public ChoiceController(ILogger<ChoiceController> logger) : base(logger)
        {
        }
    }
}