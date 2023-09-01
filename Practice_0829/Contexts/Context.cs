using Microsoft.EntityFrameworkCore;
using Practice_0829.Models.Entities;

namespace Practice_0829.Contexts;
internal class Context : DbContext
{

    public Context()
    {
    }
    public Context(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\skol\kod\c#\Practice\Practice_0829\Practice_0829\Contexts\db_lagring_test.mdf;Integrated Security=True;Connect Timeout=30");
    }



    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<TicketEntity> Tickets { get; set; }


}
