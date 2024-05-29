using LogisticService.Data;
using LogisticService.Mapper;
using LogisticService.Models;
using LogisticService.Models.Cars;
using LogisticService.Responses;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services
{
	public class CarService : ICarBrandService, ICarModelService
	{
		private readonly DataContext _context;
		private readonly IMapper<CarBrand, CarBrandEntity> _carBrandMapper;
		private readonly IMapper<CarModel, CarModelEntity> _carModelMapper;

		public CarService(DataContext context, IMapper<CarBrand, CarBrandEntity> mapper, IMapper<CarModel, CarModelEntity> carModelMapper)
		{
			_context = context;
			_carBrandMapper = mapper;
			_carModelMapper = carModelMapper;
		}

		public async Task AddCarBrandAsync(CarBrand carBrand)
		{
			await _context.CarBrands.AddAsync(_carBrandMapper.Map(carBrand));
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCarBrandAsync(CarBrand carBrand)
		{
			var brand = _context.CarBrands
				.FirstOrDefaultAsync(
					x => x.Brand.ToLowerInvariant() == carBrand.Brand.ToLowerInvariant());

			if (brand == null)
			{
				throw new Exception("No similar car brand found.");
			}

			_context.CarBrands.Remove(_carBrandMapper.Map(carBrand));

			await _context.SaveChangesAsync();
		}

		public async Task<CarBrandEntity> GetCarBrandByNameAsync(string brand)
		{
			var carBrand = await _context.CarBrands
				.FirstOrDefaultAsync(x => x.Brand.ToLowerInvariant() == brand.ToLowerInvariant());

			return carBrand;
			//return _carBrandMapper.Map(carBrand);
		}

		public async Task<CarBrandEntity> UpdateCarBrandAsync(CarBrand car)
		{
			var dbCarBrand = await _context.CarBrands.FirstOrDefaultAsync(x => x.Brand == car.Brand);

			if (dbCarBrand == null)
			{
				throw new Exception("No similar car brand found.");
			}

			dbCarBrand.Models = car.Models;

			await _context.SaveChangesAsync();

			return dbCarBrand;
			//return _carBrandMapper.Map(dbCarBrand);
		}

		public async Task<IEnumerable<CarBrandEntity>> GetCarBrandListAsync()
		{
			return await _context.CarBrands.ToListAsync();
			//return (await _context.CarBrands.ToListAsync()).Select(x => _carBrandMapper.Map(x));
		}

		public async Task AddCarModelAsync(string brand, CarModel model)
		{
			var carBrand = await _context.CarBrands.FirstOrDefaultAsync(x => x.Brand.ToLowerInvariant() == brand.ToLowerInvariant());

			if (carBrand == null)
			{
				throw new Exception("No similar car brand found.");
			}

			carBrand.Models.Add(model);

			await _context.SaveChangesAsync();
		}

		public async Task<CarModelEntity> GetCarModelAsync(string brand, string modelName)
		{
			var carBrand = await _context.CarBrands.FirstOrDefaultAsync(x => x.Brand.ToLowerInvariant() == brand.ToLowerInvariant());

			if (carBrand == null)
			{
				throw new Exception("No similar car brand found.");
			}

			var carModel = carBrand.Models.FirstOrDefault(x => x.Name == modelName);

			if (carModel == null)
			{
				throw new Exception("No similar car model found.");
			}

			return _carModelMapper.Map(carModel);
		}

		public async Task DeleteCarModelAsync(string brand, string modelName)
		{
			var carBrand = await _context.CarBrands.FirstOrDefaultAsync(x => x.Brand.ToLowerInvariant() == brand.ToLowerInvariant());

			if (carBrand == null)
			{
				throw new Exception("No similar car brand found.");
			}

			var model = carBrand.Models.FirstOrDefault(x => x.Name == modelName);

			if (model == null)
			{
				throw new Exception("No similar car model found.");
			}

			carBrand.Models.Remove(model);

			await _context.SaveChangesAsync();
		}

		public async Task<CarModelEntity> UpdateCarModelAsync(string brand, CarModel carModel)
		{
			var carBrand = await _context.CarBrands.FirstOrDefaultAsync(x => x.Brand.ToLowerInvariant() == brand.ToLowerInvariant());

			if (carBrand == null)
			{
				throw new Exception("No similar car brand found.");
			}

			var model = carBrand.Models.FirstOrDefault(x => x.Name == carModel.Name);

			if (model == null)
			{
				throw new Exception("No similar car model found.");
			}

			model = carModel;

			await _context.SaveChangesAsync();

			return _carModelMapper.Map(model);
		}

		public async Task<List<CarModelEntity>> GetCarModelListByBrandName(string brandName)
		{
			var brand = await _context.CarBrands.FirstOrDefaultAsync(x => x.Brand.ToLowerInvariant() == brandName.ToLowerInvariant());

			return brand.Models.Select(x => _carModelMapper.Map(x)).ToList();
		}
	}
}
