using ToDoListBlazor.DataModels;

namespace ToDoListBlazor.Pages.Utilisateur
{
    public class UserVM
    {
        public User model { get; init; }

        public int Id => model.Id;

        public string Prenom
        {
            get => model.Prenom;
            set => model.Prenom = value;
        }

        public string Nom
        {
            get => model.Nom;
            set => model.Nom = value;
        }

        public DateTime DateNaissance
        {
            get => model.DateNaissance;
            set => model.DateNaissance = value;
        }


        public UserVM()
        {
            model = new User();
        }

        public UserVM(User user)
        {
            model = user;
        }
    }
}
