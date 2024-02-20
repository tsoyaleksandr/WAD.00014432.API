using Microsoft.EntityFrameworkCore;
using WAD._00014432.API.DAL.Models;

namespace WAD._00014432.API.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Key> Keys { get; set; }
		public DbSet<KeyStore> KeyStores { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<KeyStore>()
				.HasMany(a => a.Keys)
				.WithOne(b => b.KeyStore)
				.HasForeignKey(b => b.KeyStoreId).OnDelete(DeleteBehavior.NoAction);
		}
	}
}
