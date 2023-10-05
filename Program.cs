using Microsoft.EntityFrameworkCore;
using LearnEF.Modeles;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MainPrg
{

    class MyPrgBest
    {


        public static void Main(string[] args) {
            Console.WriteLine("Hello, World!");
            using (var dbContext = new MDbContext()) {

                dbContext.SaveChanges();
            }


            Console.ReadKey();
        }
        public static void AddDataToTable() {
            using (var dbContext = new MDbContext()) {
                var user = new User();
                user.Id = 1;
                user.Age = 1;
                user.LastName = "LastName1";
                user.Name = "Name1";

                dbContext.User.Add(user);
                dbContext.SaveChanges();
            }
        }


    }





    class MDbContext : DbContext
    {
        private static string connetctionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Projects\\C#\\TestProjects\\LearnEF\\TestDB.mdf";


        private DbContextOptions optionsBuilder;


        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(connetctionString);
            }
        }



        public MDbContext() : base() { }

        public MDbContext(DbContextOptions options) {
            this.optionsBuilder = options;
        }


    }





    // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\C#\TestProjects\LearnEF\TestDB.mdf;Integrated Security=True



}


