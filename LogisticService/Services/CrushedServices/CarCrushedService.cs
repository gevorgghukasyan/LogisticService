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
			=> await _dataContext.CarCrushed.AddAsync(crushed);

		public async Task<IEnumerable<CarCrushed>> GetAll()
			=> await _dataContext.CarCrushed.ToListAsync();

		public async Task<CarCrushed> GetCrushedByType(bool type)
			=> await _dataContext.CarCrushed.FirstOrDefaultAsync(x => x.IsCrushed == type);
	}
}
