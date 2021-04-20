using System.Linq;
using HyejinMarichal.Todolists.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HyejinMarichal.TodoLists.Api.Controllers
{
    [ApiController]
    [Route("api/todolists")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;
        private readonly TodoItemContext _todoItemContext;


        public TodoListController(ILogger<TodoListController> logger, TodoItemContext todoItemContext)
        {
            _logger = logger;
            _todoItemContext = todoItemContext;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] int limit = 10, [FromQuery] int page = 0)
        {
            _logger.LogInformation("Action{ActionName} called.", nameof(GetAll));

           // return Ok(_todoItemContext.TodoItems.Skip(page * limit).Take(limit).OrderBy(x => x.Id).ToList());
           return Ok(_todoItemContext.TodoItems.ToList());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            _logger.LogInformation("Action{ActionName} called, with parameter id = {Id}.", nameof(Get), id);
            var todoItem = _todoItemContext.TodoItems.Find(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateOrUpdateTodoItemRequest request)
        {
            _logger.LogInformation("Action{ActionName} called, with body {RequestBody.}", nameof(Create), request);
            var todoItem = new TodoItem()
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate
            };
            _todoItemContext.TodoItems.Add(todoItem);
            _todoItemContext.SaveChanges();
            return Ok(todoItem);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CreateOrUpdateTodoItemRequest request)
        {
            _logger.LogInformation("Action{ActionName} called, with parameter id = {Id} ,with body {RequestBody}.",
                nameof(Update), id, request);
            TodoItem todoItem = _todoItemContext.TodoItems.Find(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            todoItem.Title = request.Title;
            todoItem.Description = request.Description;
            todoItem.DueDate = request.DueDate;
            _todoItemContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _logger.LogInformation("Action{ActionName} called, with parameter id = {Id}.", nameof(Delete), id);
            TodoItem todoItem = _todoItemContext.TodoItems.Find(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            _todoItemContext.TodoItems.Remove(todoItem);
            _todoItemContext.SaveChanges();
            return Ok();
        }
    }
}