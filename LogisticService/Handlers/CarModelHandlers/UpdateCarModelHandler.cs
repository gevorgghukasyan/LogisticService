using LogisticService.Commands.CarModelCommands;
using LogisticService.Models.Cars;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class UpdateCarModelHandler : IRequestHandler<UpdateCarModelCommand, CarModelEntity>
	{
		private readonly ICarModelService _carModelService;

		public UpdateCarModelHandler(ICarModelService carModelService)
		{
			_carModelService = carModelService;
		}

		public async Task<CarModelEntity> Handle(UpdateCarModelCommand request, CancellationToken cancellationToken)
		{
			var carModel = await _carModelService.GetCarModelAsync(request.Brand, request.Model.Name);

			if (carModel == null)
			{
				return default(CarModelEntity);
			}

			carModel.Type = request.Model.Type;

			return await _carModelService.UpdateCarModelAsync(request.Brand, new CarModel() { Id = carModel.Id, Type = carModel.Type, Name = carModel.Name });
		}
	}
}
