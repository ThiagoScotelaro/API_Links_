using Aula3.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace Aula3.Persistence
{
    public class EncurtaUrlDbContext : DbContext
    {
        
        public EncurtaUrlDbContext(DbContextOptions<EncurtaUrlDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<ShortLink> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ShortLink>(x =>
            {
                x.HasKey(l => l.Id);
            });
        }

       
    }
}
