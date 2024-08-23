using AwesomeSocialMedia.Users.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace AwesomeSocialMedia.Users.Infraestructure.Persistence;

public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) : base (options)
    {
            
    }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>(e =>
        {
            e.HasKey(u => u.Id);

            //Mapeamento dos valueObjects
            e.OwnsOne(u => u.Location,
                builder =>
                {
                    builder.Property(l => l.City).HasColumnName("City");
                    builder.Property(l => l.State).HasColumnName("State");
                    builder.Property(l => l.Country).HasColumnName("Country");
                });

            e.OwnsOne(u => u.Contact,
                builder =>
                {
                    builder.Property(l => l.Email).HasColumnName("Email");
                    builder.Property(l => l.WebSite).HasColumnName("WebSite");
                    builder.Property(l => l.PhoneNumber).HasColumnName("PhoneNumber");
                });

            //Ignorando a propriedade de navegação
            e.Ignore(u => u.Events);
        });
    }
}
