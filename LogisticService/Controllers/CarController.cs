using LogisticService.Models.Cars;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<CarBrand>>> GetCarBrandListAsync()
		{

			return Ok(new List<CarBrand>());
		}

		//Task AddCarBrandAsync(CarBrand carBrand);
		//Task<CarBrand> UpdateCarBrandAsync(CarBrand carBrand);
		//Task DeleteCarBrandAsync(CarBrand carBrand);
		//Task<CarBrand> GetCarBrandByBrandAsync(string brand);
	}
}
