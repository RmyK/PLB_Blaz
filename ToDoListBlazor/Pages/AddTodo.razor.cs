using Microsoft.AspNetCore.Components;
using ToDoListBlazor.DataModels;
using ToDoListBlazor.Services;

namespace ToDoListBlazor.Pages
{
    public partial class AddTodo
    {
        [Inject]
        private ToDoService toDoService { get; set; }

        [Parameter] public int? Todoid { get; set; }

        private ToDo todo;
        private bool isEdit => Todoid != null;

        private void AddTodoClick()
        {
            if (isEdit)
            {
                toDoService.UpdateTodo(todo);
            }
            else
                toDoService.AddTodo(todo);

        }

        protected override void OnParametersSet()
        {
            if (isEdit)
            {
                todo = toDoService.GetById(Todoid);
            }
            else
                todo = new ToDo();
        }
    }
}
