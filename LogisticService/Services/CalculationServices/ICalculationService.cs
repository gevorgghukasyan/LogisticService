using LogisticService.Models.CalculationModels;

namespace LogisticService.Services.CalculationServices
{
	public interface ICalculationService
	{
		float Calculate(CalculationModel calculationModel);
	}
}
