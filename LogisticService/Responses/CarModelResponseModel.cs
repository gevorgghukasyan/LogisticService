using LogisticService.Models.CalculationModels;
using LogisticService.Models.Cars;

namespace LogisticService.Responses
{
	public class CarModelEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public CarType Type { get; set; }
	}
}
