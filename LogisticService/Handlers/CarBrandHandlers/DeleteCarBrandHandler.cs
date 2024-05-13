using LogisticService.Commands.CarBrandCommands;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarBrandHandlers
{
	public class DeleteCarModelHandler : IRequestHandler<DeleteCarBrandCommand, bool>
	{
		private readonly ICarBrandService _carBrandService;

		public DeleteCarModelHandler(ICarBrandService carBrandService)
		{
			_carBrandService = carBrandService;
		}

		public async Task<bool> Handle(DeleteCarBrandCommand request, CancellationToken cancellationToken)
		{
			var carbrand = await _carBrandService.GetCarBrandByNameAsync(request.BrandName);

			if (carbrand == null)
			{
				return false;
			}

			await _carBrandService.DeleteCarBrandAsync(carbrand);

			return true;
		}
	}
}
