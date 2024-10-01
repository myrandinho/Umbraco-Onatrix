using Microsoft.EntityFrameworkCore;
using Umbraco_Onatrix.Entities;

namespace Umbraco_Onatrix.Contexts;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public required DbSet<ContactFormEntity> ContactForms { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
}
