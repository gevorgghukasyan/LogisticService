using LogisticService.Models.Authentication;
using LogisticService.Models.CalculationModels;
using LogisticService.Models.Cars;
using LogisticService.Responses;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Data
{
    public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<CarBrandEntity> CarBrands { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<CarType> CarTypes { get; set; }
	}
}
