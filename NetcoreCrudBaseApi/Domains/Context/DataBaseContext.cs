using Microsoft.EntityFrameworkCore;
using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Context;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {

    }

    public DbSet<ProfileEntity> Profile { get; set; }
    public DbSet<UserEntity> User { get; set; }
    public DbSet<PermissionEntity> Permission { get; set; }
    public DbSet<ProfilePermissionEntity> ProfilePermission { get; set; }
}
