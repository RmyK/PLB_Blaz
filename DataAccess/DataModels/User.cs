using System.ComponentModel.DataAnnotations;

namespace DataAccess.DataModels
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
