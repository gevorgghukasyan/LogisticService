using LogisticService.Models.Cars;
using LogisticService.Responses;
using MediatR;

namespace LogisticService.Commands.CarModelCommands
{
	public class UpdateCarModelCommand : IRequest<CarModelEntity>
	{
		public UpdateCarModelCommand(string brand, CarModel model)
		{
			Brand = brand;
			Model = model;
		}

		public string Brand { get; set; }
		public CarModel Model { get; set; }
	}
}
