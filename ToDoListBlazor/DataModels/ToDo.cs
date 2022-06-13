namespace ToDoListBlazor.DataModels
{
    public class ToDo
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string TodoLabel { get; set; }
        public bool IsDone { get; set; }
    }
}
