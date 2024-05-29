using LogisticService.Models.Cars;
using LogisticService.Responses;

namespace LogisticService.Services
{
	public interface ICarModelService
	{
		Task AddCarModelAsync(string brand, CarModel model);
		Task<CarModelEntity> GetCarModelAsync(string brand, string modelName);
		Task<CarModelEntity> UpdateCarModelAsync(string brand, CarModel carModel);
		Task DeleteCarModelAsync(string brand, string modelName);
		Task<List<CarModelEntity>> GetCarModelListByBrandName(string brandName);
	}
}
