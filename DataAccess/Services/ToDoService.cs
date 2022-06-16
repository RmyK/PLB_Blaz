using DataAccess.DataModels;
using DataAccess.Services.DataAcces;

namespace DataAccess.Services
{
    public class ToDoService
    {
        private readonly Repository repo;
        public ToDoService(Repository repository)
        {
            repo = repository;
        }

        public IEnumerable<ToDo> GetTodos()
        {
            return repo.GetAll<ToDo>();
        }

        public IEnumerable<ToDo> GetTodoByUserId(int id)
        {
            return repo.Where<ToDo>(t => t.UserId == id);
        }

        public void AddTodo(ToDo toDo)
        {
            repo.Insert(toDo);
        }

        public ToDo GetById(int? todoid)
        {
            return GetTodos().SingleOrDefault(t => t.Id == todoid);
        }

        public void UpdateTodo(ToDo toDo)
        {
            var todo = GetById(toDo.Id);
            todo = toDo;
        }
    }
}
