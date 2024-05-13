using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Commands.CarModelCommands
{
	public class CreateCardModelCommand : IRequest<CarModel>
	{
		public CreateCardModelCommand(string brand, CarModel model)
		{
			Brand = brand;
			Model = model;
		}

		public string Brand { get; set; }
		public CarModel Model { get; set; }
	}
}
