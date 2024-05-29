using LogisticService.Models.CalculationModels;

namespace LogisticService.Models.Cars
{
	//public enum CarTypes
	//{
	//	Sedan,
	//	Suv,
	//	Van,
	//	Pickup
	//}

	public class CarModel
	{
		public CarModel(string name, CarType type, string token)
		{
			Name = name;
			Type = type;
			Token = token;
		}

		public CarModel()
		{

		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Token { get; set; }
		public CarType Type { get; set; }
	}
}
