using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols;

namespace MainPrg
{

    class MyPrgBest
    {
        public static void Main(string[] args) {
            Console.WriteLine("Hello, World!");

            using (var dbContext = new MDbContext()) {
                var user = new User();
                user.Id = 1;
                user.Age = 1;
                user.LastName = "LastName1";
                user.Name = "Name1";

                dbContext.User.Add(user);
                dbContext.SaveChanges();
            }

            Console.ReadKey();
        }
    }


    class MDbContext : DbContext
    {

        public DbSet<User> User { get; set; }
        private string connetctionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Projects\\C#\\TestProjects\\LearnEF\\TestDB.mdf";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(connetctionString);
            }
        }


    }


    class User
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }


    }


    // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\C#\TestProjects\LearnEF\TestDB.mdf;Integrated Security=True



}


