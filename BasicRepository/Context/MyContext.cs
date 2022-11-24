using BasicRepository.Data;
using Microsoft.EntityFrameworkCore;

namespace BasicRepository.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> db) : base(db)
        {

        }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<City> City { get; set; }
    }
}
