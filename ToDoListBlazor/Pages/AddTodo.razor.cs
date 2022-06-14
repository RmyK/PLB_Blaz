using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using ToDoListBlazor.DataModels;
using ToDoListBlazor.Services;

namespace ToDoListBlazor.Pages
{
    public partial class AddTodo : IDisposable
    {
        [Inject]
        private ToDoService toDoService { get; set; }

        [Inject]
        private NavigationManager Nav { get; set; }

        [Parameter] public int? Todoid { get; set; }

        private ToDoVM todo;
        private bool isEdit => Todoid != null;

        private void LocationChanged(object sender, LocationChangedEventArgs e)
        {
            var routingMethod = e.IsNavigationIntercepted ? "HTML routing" : "Code routing";
            Console.WriteLine($"{routingMethod} - Location : {e.Location}");
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Nav.LocationChanged += LocationChanged;
        }

        private void AddTodoClick(EditContext context)
        {
            if (context.Validate())
            {
                if (isEdit)
                {
                    toDoService.UpdateTodo(todo.model);
                }
                else
                    toDoService.AddTodo(todo.model);
            }
        }

        private void InvalidSubmit(EditContext context)
        {
            foreach (var msg in context.GetValidationMessages())
            {
                Console.WriteLine(msg);
            } 
        }

        protected override void OnParametersSet()
        {
            if (isEdit)
            {
                todo = new ToDoVM(toDoService.GetById(Todoid));
            }
            else
                todo = new ToDoVM();
        }

        public void Dispose()
        {
            Nav.LocationChanged -= LocationChanged;
        }
    }
}
