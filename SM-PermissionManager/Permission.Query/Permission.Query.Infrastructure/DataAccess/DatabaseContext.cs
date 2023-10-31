using Microsoft.EntityFrameworkCore;
using Permission.Query.Domain.Entities;

namespace Permission.Query.Infrastructure.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PermissionEntity> Permissions { get; set; }
        public DbSet<PermissionTypeEntity> PermissionTypes { get; set; }
    }
}