using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Commands.CarModelCommands
{
	public class CreateCarModelCommand : IRequest<CarModel>
	{
		public CreateCarModelCommand(string brand, CarModel model)
		{
			Brand = brand;
			Model = model;
		}

		public string Brand { get; set; }
		public CarModel Model { get; set; }
	}
}
