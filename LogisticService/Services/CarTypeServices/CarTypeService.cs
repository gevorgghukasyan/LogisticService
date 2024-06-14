using LogisticService.Data;
using LogisticService.Models.CalculationModels;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.CarTypeServices
{
	public class CarTypeService : ICarTypeService
	{
		private readonly DataContext _dataContext;

		public CarTypeService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task AddCarType(CarType carType)
		{
			await _dataContext.CarTypes.AddAsync(carType);
		}

		public async Task DeleteCarType(CarType carType)
		{
			var type = await _dataContext.CarTypes.FirstOrDefaultAsync(x => x.Id == carType.Id);

			if (type == null)
			{
				throw new Exception("No similar car brand found.");
			}

			_dataContext.CarTypes.Remove(type);

			await _dataContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<CarType>> GetAllCarTypes()
		{
			return await _dataContext.CarTypes.ToListAsync();
		}

		public async Task<CarType> GetCarType(string name)
		{
			var type = await _dataContext.CarTypes.FirstOrDefaultAsync(x => x.Name == name);

			if (type == null)
			{
				throw new Exception("No similar car brand found.");
			}

			return type;
		}

		public async Task UpdateCarType(CarType carType)
		{
			var type = await _dataContext.CarTypes.FirstOrDefaultAsync(x => x.Name == carType.Name);

			if (type == null)
			{
				throw new Exception("No similar car brand found.");
			}

			type = carType;

			await _dataContext.SaveChangesAsync();
		}
	}
}
