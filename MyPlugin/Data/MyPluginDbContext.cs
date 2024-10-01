using Microsoft.EntityFrameworkCore;

namespace BTCPayServer.Plugins.MyPlugin.Data;

public class MyPluginDbContext : DbContext
{
    private readonly bool _designTime;

    public MyPluginDbContext(DbContextOptions<MyPluginDbContext> options, bool designTime = false)
        : base(options)
    {
        _designTime = designTime;
    }

    public DbSet<PluginData> PluginRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("BTCPayServer.Plugins.MyPlugin");
    }
}
