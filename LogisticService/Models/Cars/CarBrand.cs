namespace LogisticService.Models.Cars
{
	public class CarBrand
	{
		public CarBrand(string brand, List<CarModel> models)
		{
			Brand = brand;
			Models = models;
		}

		public string Brand { get; set; }
		public List<CarModel> Models { get; set; }
	}
}
