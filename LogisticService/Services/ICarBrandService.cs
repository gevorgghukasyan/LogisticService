using LogisticService.Models.Cars;

namespace LogisticService.Services
{
	public interface ICarBrandService
	{
		Task<IEnumerable<CarBrand>> GetCarBrandListAsync();
		Task AddCarBrandAsync(CarBrand carBrand);
		Task<CarBrand> UpdateCarBrandAsync(CarBrand carBrand);
		Task DeleteCarBrandAsync(CarBrand carBrand);
		Task<CarBrand> GetCarBrandByBrandAsync(string brand);
	}

	public interface ICarModelService
	{
		Task AddCarModelAsync(string brand, CarModel model);
		Task<CarModel> GetCarModelAsync(string brand, string modelName);
		Task<CarModel> UpdateCarModelAsync(string brand, CarModel carModel);
		Task DeleteCarModelAsync(string brand, string modelName);
	}
}
