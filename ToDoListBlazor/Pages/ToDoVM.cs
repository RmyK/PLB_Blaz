using DataAccess.DataModels;
using System.ComponentModel.DataAnnotations;

namespace ToDoListBlazor.Pages
{
    public class ToDoVM :IValidatableObject
    {
        public ToDo model { get; init; }

        public int Id => model.Id;

        public int Order
        {
            get => model.Order;
            set => model.Order = value;
        }

        //[Required(ErrorMessage ="Le label du todo est requis")]
        public string TodoLabel
        {
            get => model.TodoLabel;
            set => model.TodoLabel = value;
        }

        public bool IsDone
        {
            get => model.IsDone;
            set => model.IsDone = value;
        }

        public ToDoVM(ToDo toDo)
        {
            model = toDo;
        }

        public ToDoVM()
        {
            model = new ToDo();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(TodoLabel))
                yield return new ValidationResult("Le label doit être saisie", new List<string>(){ nameof(TodoLabel) });
        }
    }
}
