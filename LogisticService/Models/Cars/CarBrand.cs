namespace LogisticService.Models.Cars
{
	public class CarBrand
	{
		public CarBrand(string brand, List<CarModel> models)
		{
			Brand = brand;
			Models = models;
			//Token = token;
		}

		public CarBrand()
		{

		}

		public int Id { get; set; }
		public string Brand { get; set; }
		public string Token { get; set; }
		public List<CarModel> Models { get; set; }
	}
}
