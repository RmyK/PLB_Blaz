
using Microsoft.AspNetCore.Components;
using ToDoListBlazor.DataModels;
using ToDoListBlazor.Services;

namespace ToDoListBlazor.Pages
{
    public partial class ToDoPage
    {
        [Inject]
        private ToDoService toDoService { get; set; }

        [Parameter]
        public int? TodoId { get; set; }

        private List<ToDo> ToDos;
        private List<ToDo> TodoTobedone => ToDos.Where(t => !t.IsDone).ToList();
        private List<ToDo> TodoDone => ToDos.Where(t => t.IsDone).ToList();
        private ToDo toDoToAddOrEdit;


        protected override void OnInitialized()
        {
            ToDos = toDoService.GetTodos().ToList();
        }

        private void AjouterTodo()
        {
            toDoToAddOrEdit = new ToDo();
        }

        private void EditTodo(ToDo todo)
        {
            toDoToAddOrEdit = todo;
        }

        private void ChangeTodoStatus(int id)
        {
            var todo = ToDos.SingleOrDefault(t => t.Id == id);
            todo.IsDone = !todo.IsDone;
        }

        private void SaveTodo()
        {
            if (toDoToAddOrEdit.Id == 0)
            {
                toDoService.AddTodo(toDoToAddOrEdit);
                ToDos.Add(toDoToAddOrEdit);
            }
            else
                toDoService.UpdateTodo(toDoToAddOrEdit);

            toDoToAddOrEdit = null;
        }
    }
}
