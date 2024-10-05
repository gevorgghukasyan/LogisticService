using LogisticService.Models.Authentication;
using LogisticService.Models.CalculationModels;
using LogisticService.Models.CarCrushedModels;
using LogisticService.Models.Cars;
using LogisticService.Models.ContainerModels;
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
		public DbSet<Direction> FixedDirections { get; set; }
		public DbSet<Container> Containers { get; set; }
		public DbSet<CarCrushed> CarCrushed { get; set; }
	}
}
