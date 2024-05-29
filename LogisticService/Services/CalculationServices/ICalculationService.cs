using LogisticService.Models.CalculationModels;

namespace LogisticService.Services.CalculationServices
{
	public interface ICalculationService
	{
		float Calculate(CalculationModel calculationModel);
	}

	public class CalculationService : ICalculationService
	{
		public float Calculate(CalculationModel calculationModel)
		{
			return calculationModel.CarType.Coefficient * calculationModel.Direction.Coefficient * calculationModel.Direction.Distance;
		}
	}
}
