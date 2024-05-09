using MediatR;

namespace LogisticService.Commands.CarBrandCommands
{
	public class DeleteCarBrandCommand : IRequest<bool>
	{
		public string BrandName { get; set; }

		public DeleteCarBrandCommand(string brandName)
		{
			BrandName = brandName;
		}
	}
}
