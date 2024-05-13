using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Commands.CarBrandCommands
{
	public class CreateCarBrandCommand : IRequest<CarBrand>
	{
		public CreateCarBrandCommand(string brand, List<CarModel> models)
		{
			Brand = brand;
			Models = models;
		}

		public string Brand { get; set; }
		public List<CarModel> Models { get; set; }
	}
}
