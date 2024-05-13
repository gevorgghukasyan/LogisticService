using LogisticService.Commands.CarModelCommands;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class DeleteCarModelHandler : IRequestHandler<DeleteCarModelCommand, bool>
	{
		private readonly ICarModelService _carModelService;

		public DeleteCarModelHandler(ICarModelService carModelService)
		{
			_carModelService = carModelService;
		}

		public async Task<bool> Handle(DeleteCarModelCommand request, CancellationToken cancellationToken)
		{
			var carModel = await _carModelService.GetCarModelAsync(request.BrandName, request.ModelName);

			if (carModel == null)
			{
				return false;
			}

			await _carModelService.DeleteCarModelAsync(request.BrandName, request.ModelName);

			return true;
		}
	}
}
