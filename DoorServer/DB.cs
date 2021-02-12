using Microsoft.EntityFrameworkCore;

namespace DoorServer
{
	public class Db : DbContext
	{
		public DbSet<DoorOpensCollection> Ints { get; set; }
		
		private static string _connectionString()
		{
			Configuration.Configure();

			return Configuration.Config.ConnectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseNpgsql(_connectionString());
		}

	

		
	}
}