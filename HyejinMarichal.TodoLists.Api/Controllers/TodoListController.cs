using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HyejinMarichal.TodoLists.Api.Controllers
{
    [ApiController]
    [Route("api/todolists")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;

        public TodoListController(ILogger<TodoListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Action{ActionName} called.", nameof(GetAll));
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Action{ActionName} called, with parameter id = {Id}.", nameof(Get), id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrUpdateTodoItemRequest request)
        {
            _logger.LogInformation("Action{ActionName} called, with body {RequestBody.}", nameof(Create), request);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CreateOrUpdateTodoItemRequest request)
        {
            _logger.LogInformation("Action{ActionName} called, with parameter id = {Id} ,with body {RequestBody}.", nameof(Update), id, request);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Action{ActionName} called, with parameter id = {Id}.", nameof(Delete), id);
            return Ok();
        }
    }
}