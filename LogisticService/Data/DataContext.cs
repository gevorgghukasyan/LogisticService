using LogisticService.Models.Cars;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<CarBrand> CarBrands { get; set; }
	}
}
