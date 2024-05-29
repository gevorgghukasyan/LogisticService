using LogisticService.Models.Cars;
using LogisticService.Responses;
using MediatR;

namespace LogisticService.Commands.CarBrandCommands
{
	public class CreateCarBrandCommand : IRequest<CarBrandEntity>
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
