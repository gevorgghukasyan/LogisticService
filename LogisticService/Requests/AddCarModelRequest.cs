using LogisticService.Models.Cars;

namespace LogisticService.Requests
{
	public class AddCarModelRequest
	{
		public AddCarModelRequest(string brand, string token, CarModel model)
		{
			Brand = brand;
			Token = token;
			Model = model;
		}

		public string Brand { get; set; }
		public string Token { get; set; }
		public CarModel Model { get; set; }
	}
}
