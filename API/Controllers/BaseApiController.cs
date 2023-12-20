using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase where T : ControllerBase
    {
        protected readonly ILogger<T> _logger;

        protected BaseApiController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}
