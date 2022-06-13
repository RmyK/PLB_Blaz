
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


        protected override void OnInitialized()
        {
            ToDos = toDoService.GetTodos().ToList();
        }
    }
}
