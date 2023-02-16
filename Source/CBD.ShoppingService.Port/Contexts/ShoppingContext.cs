using Microsoft.EntityFrameworkCore;
using CBD.ShoppingService.Core.Models;

namespace ShoppingService.Port.Contexts;

public class ShoppingContext : DbContext {
	public ShoppingContext(DbContextOptions options) : base(options) {
	}
	public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder) {
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Product>(entity => {
			entity.HasKey(product => product.Id);
			entity.HasIndex(product => product.Name).IsUnique();
		});
	}
}