using LogisticService.Commands.AuthenticationCommands;
using LogisticService.Commands.CarBrandCommands;
using LogisticService.Commands.CarModelCommands;
using LogisticService.Models.Cars;
using LogisticService.Queries.CarBrandQueries;
using LogisticService.Queries.CarModelQueries;
using LogisticService.Requests;
using LogisticService.Responses;
using LogisticService.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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

		[HttpPost("[action]")]
		public async Task<ActionResult<AuthorizationResponse>> Authorize(AuthorizationRequest request)
		{
			var response = await _mediator.Send(new AuthorizeCommand(request));

			return Ok(response);
		}

		[AllowAnonymous]
		[HttpPost("[action]")]
		public async Task<ActionResult<string>> Login([FromHeader] string username, [FromHeader] string password)
		{
			try
			{
				if (username.IsNullOrEmpty() || password.IsNullOrEmpty())
				{
					throw new ArgumentException("Argument can't be null.");
				}

				var user = await _mediator.Send(new LoginCommand(username, password));
				//	var user = await _service.Login(username, password);

				var jwtService = new JwtService("ForTheLoveOfGodStoreAndLoadThisSecurely", "yourIssuer");
				var token = jwtService.GenerateToken(user);

				return Ok(token);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
