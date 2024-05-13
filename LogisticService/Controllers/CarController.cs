using LogisticService.Commands.CarBrandCommands;
using LogisticService.Commands.CarModelCommands;
using LogisticService.Models.Cars;
using LogisticService.Queries.CarBrandQueries;
using LogisticService.Queries.CarModelQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<ActionResult<List<CarBrand>>> GetCarBrandListAsync()
		{
			var brandes = await _mediator.Send(new GetCarBrandListQuery());

			return Ok(brandes);
		}

		[HttpPost]
		public async Task<ActionResult<CarBrand>> AddCarBrandAsync(CarBrand carBrand)
		{
			var newBrand = await _mediator.Send(new CreateCarBrandCommand(carBrand.Brand, carBrand.Models));

			return Ok(newBrand);
		}

		[HttpPut]
		public async Task<ActionResult<CarBrand>> UpdateCarBrandAsync(CarBrand carBrand)
		{
			var updatedBrand = await _mediator.Send(new UpdateCarBrandCommand(carBrand.Brand, carBrand.Models));

			return Ok(updatedBrand);
		}

		[HttpDelete]
		public async Task<ActionResult<bool>> DeleteCarBrandAsync(CarBrand carBrand)
		{
			var isSuccess = await _mediator.Send(new DeleteCarBrandCommand(carBrand.Brand));

			return Ok(isSuccess);
		}

		[HttpGet("CarList")]
		public async Task<ActionResult<CarBrand>> GetCarBrandByBrandAsync(string brand)
		{
			var brd = await _mediator.Send(new GetCarBrandByBrandNameQuery(brand));

			return Ok(brd);
		}

		[HttpPost("CarModel")]
		public async Task<ActionResult<CarModel>> AddCarModelAsync(string brand, CarModel model)
		{
			var carModel = await _mediator.Send(new CreateCarModelCommand(brand, model));

			return Ok(carModel);
		}

		[HttpGet("CarModel")]
		public async Task<ActionResult<CarModel>> GetCarModelAsync(string brand, string modelName)
		{
			var carModel = await _mediator.Send(new GetCarModelByModelNameQuery(brand, modelName));

			return Ok(carModel);
		}

		[HttpPut("CarModel")]
		public async Task<ActionResult<CarModel>> UpdateCarModelAsync(string brand, CarModel carModel)
		{
			var model = await _mediator.Send(new UpdateCarModelCommand(brand, carModel));

			return Ok(model);
		}

		[HttpDelete("CarModel")]
		public async Task<ActionResult<bool>> DeleteCarModelAsync(string brand, string modelName)
		{
			var isSuccess = await _mediator.Send(new DeleteCarModelCommand(brand, modelName));

			return isSuccess;
		}

		[HttpGet("CarModelList")]
		public async Task<ActionResult<List<CarModel>>> GetCarModelListByBrandName(string brandName)
		{
			var carModels = await _mediator.Send(GetCarModelListByBrandName(brandName));

			return Ok(carModels);
		}
	}
}
