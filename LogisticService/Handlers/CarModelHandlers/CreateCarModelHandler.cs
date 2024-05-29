using LogisticService.Commands.CarModelCommands;
using LogisticService.Models.Cars;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class CreateCarModelHandler : IRequestHandler<CreateCarModelCommand, CarModelEntity>
	{
		private readonly ICarModelService _carModelService;

		public CreateCarModelHandler(ICarModelService carModelService)
		{
			_carModelService = carModelService;
		}

		public async Task<CarModelEntity> Handle(CreateCarModelCommand request, CancellationToken cancellationToken)
		{
			await _carModelService.AddCarModelAsync(request.Brand, request.Model);

			return new CarModelEntity() { Id = request.Model.Id, Name = request.Model.Name, Type = request.Model.Type };
		}
	}
}
