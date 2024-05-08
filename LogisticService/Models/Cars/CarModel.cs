namespace LogisticService.Models.Cars
{
	public enum CarType
	{
		Sedan,
		Suv,
		Van,
		Pickup
	}

	public class CarModel
	{
		public CarModel(string name, CarType type)
		{
			Name = name;
			Type = type;
		}

		public string Name { get; set; }
		public CarType Type { get; set; }
	}
}
