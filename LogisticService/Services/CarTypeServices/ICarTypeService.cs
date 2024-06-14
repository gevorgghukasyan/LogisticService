using LogisticService.Models.CalculationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LogisticService.Services.CarTypeServices
{
	public interface ICarTypeService
	{
		Task AddCarType(CarType carType);
		Task<CarType> GetCarType(string name);
		Task<IEnumerable<CarType>> GetAllCarTypes();
		Task UpdateCarType(CarType carType);
		Task DeleteCarType(CarType carType);
	}
}
