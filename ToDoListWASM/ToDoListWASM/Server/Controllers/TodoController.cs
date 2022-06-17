using DataAccess.DataModels;
using DataAccess.Services;
using Microsoft.AspNetCore.Mvc;
using ToDoListWASM.Shared.DTOs;

namespace ToDoListWASM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ToDoService todoSrv;
        public TodoController(ToDoService toDoService)
        {
            todoSrv = toDoService;
        }

        //[HttpGet]
        //[Route("getall")]
        [HttpGet("getall")]
        public IEnumerable<TodoDTO> GetAllTodos()
        {
            return todoSrv.GetTodos().Select(t =>
                new TodoDTO()
                {
                    Id = t.Id,
                    IsDone = t.IsDone,
                    Order = t.Order,
                    TodoLabel = t.TodoLabel,
                    UserId = t.UserId
                });
        }

        [HttpPost]
        public IActionResult InsertTodo(TodoDTO dTO)
        {
            try
            {
                todoSrv.AddTodo(new ToDo()
                {
                    Id = dTO.Id,
                    IsDone = dTO.IsDone,
                    Order = dTO.Order,
                    TodoLabel = dTO.TodoLabel,
                    UserId = dTO.UserId
                });

                return Ok(true);
            }
            catch (Exception)
            {
                return Problem(statusCode: 999, detail: "message d'erreur custom");
            }
        }
    }
}
