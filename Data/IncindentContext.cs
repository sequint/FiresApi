using Microsoft.EntityFrameworkCore;
using FiresApi.Models;

namespace FiresApi.Data;

public class IncindentContext : DbContext
{
    public IncindentContext (DbContextOptions<IncindentContext> options)
        : base(options)
    {
    }

    public DbSet<Incident> Incident { get; set; } = default!;
}
