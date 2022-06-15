using ToDoListBlazor.DataModels;
using ToDoListBlazor.Services.DataAcces;

namespace ToDoListBlazor.Services
{
    public class ToDoService
    {
        private readonly Repository repo;
        public ToDoService( Repository repository)
        {
            repo = repository;
        }

        public IEnumerable<ToDo> GetTodos()
        {
            return repo.GetAll<ToDo>();
        }

        public void AddTodo(ToDo toDo)
        {
            repo.Insert(toDo);
        }

        internal ToDo GetById(int? todoid)
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
