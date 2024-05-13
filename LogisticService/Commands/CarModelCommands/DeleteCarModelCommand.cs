using LogisticService.Models.Cars;
using MediatR;

namespace LogisticService.Commands.CarModelCommands
{
	public class DeleteCarModelCommand : IRequest<bool>
	{
		public string BrandName { get; set; }
		public string ModelName { get; set; }

		public DeleteCarModelCommand(string brandName, string modelName)
		{
			BrandName = brandName;
			ModelName = modelName;
		}
	}
}
