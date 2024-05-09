using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Commands.CarBrandCommands
{
	public class UpdateCarBrandCommand : IRequest<CarBrand>
	{
		public UpdateCarBrandCommand(string brand, List<CarModel> models)
		{
			Brand = brand;
			Models = models;
		}

		public string Brand { get; set; }
		public List<CarModel> Models { get; set; }
	}
}
