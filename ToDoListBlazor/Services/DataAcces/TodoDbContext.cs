using Microsoft.EntityFrameworkCore;
using ToDoListBlazor.DataModels;

namespace ToDoListBlazor.Services.DataAcces
{
    public class TodoDbContext : DbContext
    {
        private string? cs;

        public TodoDbContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                if (cs == null)
                {
                    var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build();
                    cs = config["ConnectionStrings:AppCS"];
                }
                optionsBuilder.UseSqlServer(cs);
            }
        }

        public virtual DbSet<ToDo> Todos { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User() { Id = 1, DateNaissance = new DateTime(1980, 03, 15), Nom = "Car", Prenom = "Otto" });

            modelBuilder.Entity<ToDo>().HasData(new ToDo() {Id = 1, IsDone=false, Order=1, TodoLabel="Donner à manger au chat", UserId=1 });

            //modelBuilder.Entity<ToDo>().HasOne(t => t.User).WithMany();
        }
    }
}
