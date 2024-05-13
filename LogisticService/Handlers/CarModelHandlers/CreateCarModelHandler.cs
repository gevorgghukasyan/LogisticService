using LogisticService.Commands.CarModelCommands;
using LogisticService.Models.Cars;
using LogisticService.Services;
using MediatR;

namespace LogisticService.Handlers.CarModelHandlers
{
	public class CreateCarModelHandler : IRequestHandler<CreateCarModelCommand, CarModel>
	{
		private readonly ICarModelService _carModelService;

		public CreateCarModelHandler(ICarModelService carModelService)
		{
			_carModelService = carModelService;
		}

		public async Task<CarModel> Handle(CreateCarModelCommand request, CancellationToken cancellationToken)
		{
			await _carModelService.AddCarModelAsync(request.Brand, request.Model);

			return request.Model;
		}
	}
}
