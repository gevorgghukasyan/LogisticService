using LogisticService.Commands.AuthenticationCommands;
using LogisticService.Commands.CarBrandCommands;
using LogisticService.Commands.CarModelCommands;
using LogisticService.Models.Authentication;
using LogisticService.Models.CalculationModels;
using LogisticService.Models.CarCrushedModels;
using LogisticService.Models.Cars;
using LogisticService.Models.ContainerModels;
using LogisticService.Queries.CarBrandQueries;
using LogisticService.Queries.CarModelQueries;
using LogisticService.Requests;
using LogisticService.Responses;
using LogisticService.Services;
using LogisticService.Services.CarTypeServices;
using LogisticService.Services.ContainerServices;
using LogisticService.Services.CrushedServices;
using LogisticService.Services.DirectionServices;
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
		private readonly IContainerService _containerService;
		private readonly IDirectionService _directionService;
		private readonly ICarTypeService _carTypeService;
		private readonly ICarCrushedService _carCrushedService;

		public CarController(
			IMediator mediator,
			IConfiguration configuration,
			IContainerService containerService,
			IDirectionService directionService,
			ICarTypeService carTypeService,
			ICarCrushedService carCrushedService)
		{
			_mediator = mediator;
			_configuration = configuration;
			_containerService = containerService;
			_directionService = directionService;
			_carTypeService = carTypeService;
			_carCrushedService = carCrushedService;
		}

		#region CarCrushed
		[HttpGet("[action]")]
		public async Task<ActionResult<Container>> GetCarCrushedByTypeAsync(GetCarCrushedByTypeRequest request)
		{
			var cc = await _carCrushedService.GetCrushedByType(request.Type);

			return Ok(cc);
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<Container>>> GetCarCrushedAsync()
		{
			var ccs = await _carCrushedService.GetAll();

			return Ok(ccs);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<IEnumerable<Container>>> AddCarCrushedAsync(CarCrushed carCrushed)
		{
			await _carCrushedService.AddCrushed(carCrushed);
			return Ok();
		}
		#endregion

		#region CarType

		[HttpPost("[action]")]
		public async Task<ActionResult> AddCarTypeAsync(CarType carType)
		{
			await _carTypeService.AddCarType(carType);
			return Ok();
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<CarType>> GetCarTypeAsync(GetCarTypeRequest request)
		{
			var ct = await _carTypeService.GetCarType(request.Name);

			return Ok(ct);
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<Direction>>> GetCarTypesAsync(GetCarTypesRequest request)
		{
			var cts = await _carTypeService.GetAllCarTypes();

			return Ok(cts);
		}

		[HttpPut("[action]")]
		public async Task<ActionResult> UpdateCarTypeAsync(CarType carType)
		{
			await _carTypeService.UpdateCarType(carType);

			return Ok();
		}

		[HttpDelete("[action]")]
		public async Task<ActionResult> DeleteCarTypeAsync(CarType carType)
		{
			await _carTypeService.DeleteCarType(carType);

			return Ok();
		}

		#endregion

		#region FixedDirections

		[HttpPost("[action]")]
		public async Task<ActionResult> AddFixedDirectionAsync(Direction direction)
		{
			await _directionService.AddFixedDiraction(direction);
			return Ok();
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<Direction>> GetFixedDirectionAsync(GetFixedDirectionRequest request)
		{
			var fd = await _directionService.GetFixedDirection(request.From, request.To);

			return Ok(fd);
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<Direction>>> GetFixedDirectionsAsync(GetFixedDirectionsRequest request)
		{
			var fds = await _directionService.GetAllFixedDirections();

			return Ok(fds);
		}

		[HttpPut("[action]")]
		public async Task<ActionResult> UpdateFixedDirectionAsync(Direction direction)
		{
			await _directionService.UpdateDirection(direction);

			return Ok();
		}

		[HttpDelete("[action]")]
		public async Task<ActionResult> DeleteFixedDirectionAsync(Direction direction)
		{
			await _directionService.DeleteDirection(direction);

			return Ok();
		}

		#endregion

		#region Container
		[HttpGet("[action]")]
		public async Task<ActionResult<Container>> GetContainerByTypeAsync(ContainerRequest request)
		{
			var container = await _containerService.GetContainer(request.InClose);

			return Ok(container);
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<IEnumerable<Container>>> GetContainersAsync(GetContainerRequest request)
		{
			var containers = await _containerService.GetContainers();

			return Ok(containers);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<IEnumerable<Container>>> AddContainerAsync(Container container)
		{
			await _containerService.AddContainer(container);
			return Ok();
		}
		#endregion

		#region cqrs used
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
		#endregion
	}
}
