using LogisticService.Models.Cars;
using LogisticService.Responses;

namespace LogisticService.Services
{
	public interface ICarBrandService
	{
		Task<IEnumerable<CarBrandEntity>> GetCarBrandListAsync();
		Task AddCarBrandAsync(CarBrand carBrand);
		Task<CarBrandEntity> UpdateCarBrandAsync(CarBrand carBrand);
		Task DeleteCarBrandAsync(CarBrand carBrand);
		Task<CarBrandEntity> GetCarBrandByNameAsync(string brand);
	}
}
