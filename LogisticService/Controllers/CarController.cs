using LogisticService.Commands.AuthenticationCommands;
using LogisticService.Commands.CarBrandCommands;
using LogisticService.Commands.CarModelCommands;
using LogisticService.Models.Authentication;
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
	[Authorize]
	public class CarController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly IConfiguration _configuration;

		public CarController(IMediator mediator, IConfiguration configuration)
		{
			_mediator = mediator;
			_configuration = configuration;
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<List<CarBrandEntity>>> GetCarBrandListAsync(GetCarBrandListRequest request)
		{
			var brandes = await _mediator.Send(new GetCarBrandListQuery());

			return Ok(brandes);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<CarBrand>> AddCarBrandAsync(CarBrand carBrand)
		{
			var newBrand = await _mediator.Send(new CreateCarBrandCommand(carBrand.Brand, carBrand.Models));

			return Ok(newBrand);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<CarBrand>> UpdateCarBrandAsync(CarBrand carBrand)
		{
			var updatedBrand = await _mediator.Send(new UpdateCarBrandCommand(carBrand.Brand, carBrand.Models));

			return Ok(updatedBrand);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<bool>> DeleteCarBrandAsync(CarBrand carBrand)
		{
			var isSuccess = await _mediator.Send(new DeleteCarBrandCommand(carBrand.Brand));

			return Ok(isSuccess);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<CarBrand>> GetCarBrandByBrandAsync(GetCarBrandByBrandRequest request)
		{
			var brd = await _mediator.Send(new GetCarBrandByBrandNameQuery(request.Brand));

			return Ok(brd);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<CarModel>> AddCarModelAsync(AddCarModelRequest request)
		{
			var carModel = await _mediator.Send(new CreateCarModelCommand(request.Brand, request.Model));

			return Ok(carModel);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<CarModel>> GetCarModelAsync(GetCarModelRequest request)
		{
			var carModel = await _mediator.Send(new GetCarModelByModelNameQuery(request.Brand, request.ModelName));

			return Ok(carModel);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<CarModel>> UpdateCarModelAsync(UpdateCarModelRequest request)
		{
			var model = await _mediator.Send(new UpdateCarModelCommand(request.Brand, request.Model));

			return Ok(model);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<bool>> DeleteCarModelAsync(DeleteCarModelRequest request)
		{
			var isSuccess = await _mediator.Send(new DeleteCarModelCommand(request.Brand, request.ModelName));

			return isSuccess;
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<List<CarModel>>> GetCarModelListByBrandNameAsync(GetCarModelListByBrandNameRequest request)
		{
			var carModels = await _mediator.Send(new GetCarBrandByBrandNameQuery(request.BrandName));

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
		public async Task<ActionResult<Tuple<string, string>>> Login([FromHeader] string username, [FromHeader] string password)
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
				var tokens = jwtService.GenerateTokens(user);

				return Ok(tokens);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[AllowAnonymous]
		[HttpPost("[action]")]
		public ActionResult<TokenResponse> RefreshToken(string refreshToken)
		{
			var jwtService = new JwtService("ForTheLoveOfGodStoreAndLoadThisSecurely", "yourIssuer");
			var tokens = jwtService.RefreshToken(refreshToken);

			return Ok(tokens);
		}
	}
}
