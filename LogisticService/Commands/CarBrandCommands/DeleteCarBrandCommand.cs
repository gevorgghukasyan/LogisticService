using MediatR;

namespace LogisticService.Commands.CarBrandCommands
{
	public class DeleteCarModelCommand : IRequest<bool>
	{
		public string BrandName { get; set; }

		public DeleteCarModelCommand(string brandName)
		{
			BrandName = brandName;
		}
	}
}
