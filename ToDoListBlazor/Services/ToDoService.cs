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
            toDo.Id = ToDos.Select(t => t.Id).Max() + 1;
            toDo.Order = ToDos.Select(t => t.Order).Max() + 1;
            ToDos.Add(toDo);
        }

        internal ToDo GetById(int? todoid)
        {
            return ToDos.SingleOrDefault(t => t.Id == todoid);
        }

        public void UpdateTodo(ToDo toDo)
        {
            var todo = GetById(toDo.Id);
            todo = toDo;
        }
    }
}
