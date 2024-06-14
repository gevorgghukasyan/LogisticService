using LogisticService.Models.CarCrushedModels;

namespace LogisticService.Services.CrushedServices
{
	public interface ICarCrushedService
	{
		Task<CarCrushed> GetCrushedByType(bool type);
		Task<IEnumerable<CarCrushed>> GetAll();
		Task AddCrushed(CarCrushed crushed);
	}
}
