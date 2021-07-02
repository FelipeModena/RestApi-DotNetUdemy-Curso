using Microsoft.EntityFrameworkCore;

namespace ApiRestComASPNet.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        { }
        public DbSet<Person> Person { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
