using LogisticService.Models.Cars;

namespace LogisticService.Services
{
	public interface ICarModelService
	{
		Task AddCarModelAsync(string brand, CarModel model);
		Task<CarModel> GetCarModelAsync(string brand, string modelName);
		Task<CarModel> UpdateCarModelAsync(string brand, CarModel carModel);
		Task DeleteCarModelAsync(string brand, string modelName);
		Task<List<CarModel>> GetCarModelListByBrandName(string brandName);
	}
}
