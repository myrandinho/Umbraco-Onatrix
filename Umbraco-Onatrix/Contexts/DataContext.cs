using Microsoft.EntityFrameworkCore;
using Umbraco_Onatrix.Entities;

namespace Umbraco_Onatrix.Contexts;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options)
	{
	}

	public required DbSet<ContactFormEntity> ContactForms { get; set; }
	public required DbSet<GetHelpEntity> HelpForm { get; set; }
	public required DbSet<MessageFormEntity> MessageForms { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
	}
}
