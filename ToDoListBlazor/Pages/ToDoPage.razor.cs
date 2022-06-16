
using DataAccess.DataModels;
using DataAccess.Services;
using Microsoft.AspNetCore.Components;

namespace ToDoListBlazor.Pages
{
    public partial class ToDoPage
    {
        [Inject] private ToDoService toDoService { get; set; }
        [Inject] private NavigationManager nav { get; set; }
        [Inject] private UserService usrSrv { get; set; }
        [Parameter] public int? TodoId { get; set; }

        private List<ToDo> ToDos;
        private ToDo toDoToAddOrEdit;
        private User currentUser;
        private List<(string Title, int Order, List<ToDo> ToDos)> TodoLists;
        private bool isAddingList;
        private string newToDoListLabel;

        protected override void OnInitialized()
        {
            currentUser = usrSrv.GetCurrentUser;
            if (currentUser == null)
                nav.NavigateTo("/");
            ToDos = toDoService.GetTodoByUserId(currentUser.Id).ToList();
            TodoLists = new();
            TodoLists.Add(("To Do",1, ToDos.Where(t => !t.IsDone).ToList()));
            TodoLists.Add(("Done",2, ToDos.Where(t => t.IsDone).ToList()));
        }

        private void AjouterTodo() => toDoToAddOrEdit = new ToDo();
        private void EditTodo(ToDo todo) => toDoToAddOrEdit = todo;
        private void AddTodoListBtnClick() => isAddingList = true;
        private void AddTodoList()
        {
            TodoLists.Add((newToDoListLabel, TodoLists.Select(t => t.Order).Max() + 1, new List<ToDo>()));
            isAddingList = false;
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
