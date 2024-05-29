using LogisticService.Models.Cars;

namespace LogisticService.Responses
{
	public class CarBrandEntity
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public List<CarModel> Models { get; set; }
	}
}
