using LogisticService.Models.CalculationModels;

namespace LogisticService.Services.CalculationServices
{
	public class CalculationService : ICalculationService
	{
		public float Calculate(CalculationModel calculationModel)
		{
			return calculationModel.CarType.Coefficient *
				calculationModel.Direction.Price *
				calculationModel.Direction.Distance *
				calculationModel.Container.Coefficient;
		}
	}
}
