using Microsoft.EntityFrameworkCore;
using FiresApi.Models;

namespace FiresApi.Context;

public class IncidentContext : DbContext
{
	public IncidentContext(DbContextOptions<IncidentContext> options)
		: base(options)
	{
	}

	public DbSet<Incident> Incidents { get; set; } = null!;
}
