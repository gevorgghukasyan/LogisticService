using LogisticService.Models.Cars;
using LogisticService.Responses;
using MediatR;

namespace LogisticService.Commands.CarModelCommands
{
	public class CreateCarModelCommand : IRequest<CarModelEntity>
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
