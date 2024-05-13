using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Commands.CarBrandCommands
{
	public class UpdateCarModelCommand : IRequest<CarBrand>
	{
		public UpdateCarModelCommand(string brand, List<CarModel> models)
		{
			Brand = brand;
			Models = models;
		}

		public string Brand { get; set; }
		public List<CarModel> Models { get; set; }
	}
}
