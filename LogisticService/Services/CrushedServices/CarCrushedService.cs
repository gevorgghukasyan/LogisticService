using LogisticService.Data;
using LogisticService.Models.CarCrushedModels;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.CrushedServices
{
	public class CarCrushedService : ICarCrushedService
	{
		private readonly DataContext _dataContext;

		public CarCrushedService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task AddCrushed(CarCrushed crushed)
			=> await _dataContext.CarCrusheds.AddAsync(crushed);

		public async Task<IEnumerable<CarCrushed>> GetAll()
			=> await _dataContext.CarCrusheds.ToListAsync();

		public async Task<CarCrushed> GetCrushedByType(bool type)
			=> await _dataContext.CarCrusheds.FirstOrDefaultAsync(x => x.IsCrushed == type);
	}
}
