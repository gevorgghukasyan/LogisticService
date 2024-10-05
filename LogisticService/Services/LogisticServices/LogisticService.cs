using LogisticService.Models.CalculationModels;
using LogisticService.Models.LogisticServiceModel;
using LogisticService.Services.CalculationServices;
using LogisticService.Services.CarTypeServices;
using LogisticService.Services.ContainerServices;
using LogisticService.Services.DirectionServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;

namespace LogisticService.Services.LogisticServices
{
	public class LogisticService : ILogisticService
	{
		private readonly IDirectionService _directionService;
		private readonly ICalculationService _calculationService;
		private readonly ICarTypeService _carTypeService;
		private readonly IContainerService _containerService;


		public LogisticService(
			IDirectionService directionService,
			ICalculationService calculationService,
			ICarTypeService carTypeService,
			IContainerService containerService)
		{
			_directionService = directionService;
			_calculationService = calculationService;
			_carTypeService = carTypeService;
			_containerService = containerService;
		}

		public async Task<float> GetPrice(LogisticModel logisticModel)
		{
			var direction = await _directionService.GetFixedDirection(logisticModel.From, logisticModel.To);
			var carType = await _carTypeService.GetCarType(logisticModel.CarType);
			var container = await _containerService.GetContainer(logisticModel.InClose);

			return _calculationService.Calculate(new CalculationModel(carType, direction, container));
		}
	}
}
