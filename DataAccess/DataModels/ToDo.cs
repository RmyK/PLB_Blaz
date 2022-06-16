using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public class ToDo
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string TodoLabel { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
