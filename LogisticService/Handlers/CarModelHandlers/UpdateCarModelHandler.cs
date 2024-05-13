using LogisticService.Commands.CarModelCommands;
using LogisticService.Models.Cars;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class UpdateCarModelHandler : IRequestHandler<UpdateCarModelCommand, CarModel>
	{
		private readonly ICarModelService _carModelService;

		public UpdateCarModelHandler(ICarModelService carModelService)
		{
			_carModelService = carModelService;
		}

		public async Task<CarModel> Handle(UpdateCarModelCommand request, CancellationToken cancellationToken)
		{
			var carModel = await _carModelService.GetCarModelAsync(request.Brand, request.Model.Name);

			if (carModel == null)
			{
				return default(CarModel);
			}

			carModel.Type = request.Model.Type;

			return await _carModelService.UpdateCarModelAsync(request.Brand, carModel);
		}
	}
}
