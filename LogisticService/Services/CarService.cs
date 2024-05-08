using LogisticService.Data;
using LogisticService.Models.Cars;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data.Entity;

namespace LogisticService.Services
{
	public class CarService : ICarBrandService, ICarModelService
	{
		private readonly DataContext _context;

		public CarService(DataContext context)
		{
			_context = context;
		}

		public async Task AddCarBrandAsync(CarBrand carBrand)
		{
			await _context.CarBrands.AddAsync(carBrand);
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

			_context.CarBrands.Remove(carBrand);

			await _context.SaveChangesAsync();
		}

		public Task<CarBrand> GetCarBrandByBrandAsync(string brand)
		{
			var carBrand = _context.CarBrands
				.FirstOrDefaultAsync(x => x.Brand.ToLowerInvariant() == brand.ToLowerInvariant());

			return carBrand;
		}

		public async Task<CarBrand> UpdateCarBrandAsync(CarBrand car)
		{
			var dbCarBrand = await _context.CarBrands.FirstOrDefaultAsync(x => x.Brand == car.Brand);

			if (dbCarBrand == null)
			{
				throw new Exception("No similar car brand found.");
			}

			dbCarBrand.Models = car.Models;

			await _context.SaveChangesAsync();

			return dbCarBrand;
		}

		public async Task<IEnumerable<CarBrand>> GetCarBrandListAsync()
		{
			return await _context.CarBrands.ToListAsync();
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

		public async Task<CarModel> GetCarModelAsync(string brand, string modelName)
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

			return carModel;
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

		public async Task<CarModel> UpdateCarModelAsync(string brand, CarModel carModel)
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

			return model;
		}
	}
}
