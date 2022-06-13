using ToDoListBlazor.DataModels;

namespace ToDoListBlazor.Services
{
    public class ToDoService
    {
        private List<ToDo> ToDos;

        public ToDoService()
        {
            ToDos = new List<ToDo>()
            {
                new ToDo(){Id = 1, Order = 2, TodoLabel="Envoie un mail à Otto"},
                new ToDo(){Id = 2, Order = 3, TodoLabel="Acheter du lait"},
                new ToDo(){Id = 3, Order = 1, TodoLabel="Réunion avec Paul"}
            };

        }

        public IEnumerable<ToDo> GetTodos()
        {
            return ToDos;
        }

        public void AddTodo(ToDo toDo)
        {
            ToDos.Add(toDo);
        }
    }
}
