using LogisticService.Models.CalculationModels;
using LogisticService.Models.LogisticServiceModel;

namespace LogisticService.Services.LogisticServices
{
	public interface ILogisticService
	{
		Task<float> GetPrice(LogisticModel logisticModel);
	}
}
