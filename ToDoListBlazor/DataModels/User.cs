using System.ComponentModel.DataAnnotations;

namespace ToDoListBlazor.DataModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public DateTime DateNaissance { get; set; }
    }
}
