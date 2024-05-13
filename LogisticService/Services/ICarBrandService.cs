using LogisticService.Models.Cars;

namespace LogisticService.Services
{
	public interface ICarBrandService
	{
		Task<IEnumerable<CarBrand>> GetCarBrandListAsync();
		Task AddCarBrandAsync(CarBrand carBrand);
		Task<CarBrand> UpdateCarBrandAsync(CarBrand carBrand);
		Task DeleteCarBrandAsync(CarBrand carBrand);
		Task<CarBrand> GetCarBrandByNameAsync(string brand);
	}
}
