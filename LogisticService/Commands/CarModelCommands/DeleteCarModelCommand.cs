using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Commands.CarModelCommands
{
	public class DeleteCarModelCommand : IRequest<bool>
	{
		public string BrandName { get; set; }
		public CarModel CarModel { get; set; }

		public DeleteCarModelCommand(string brandName, CarModel carModel)
		{
			BrandName = brandName;
			CarModel = carModel;
		}
	}
}
