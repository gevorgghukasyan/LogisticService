using LogisticService.Data;
using LogisticService.Models.CalculationModels;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.DirectionServices
{
	public class DirectionService : IDirectionService
	{
		private readonly DataContext _dataContext;

		public DirectionService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task AddFixedDiraction(Direction direction)
		{
			await _dataContext.FixedDirections.AddAsync(direction);
		}

		public async Task DeleteDirection(Direction direction)
		{
			var dir = await _dataContext.FixedDirections.FirstOrDefaultAsync(x => x.From.ToLower() == direction.From.ToLower() && x.To.ToLower() == direction.To.ToLower());

			if (dir == null)
			{
				throw new Exception("No similar car brand found.");
			}

			_dataContext.FixedDirections.Remove(dir);

			await _dataContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<Direction>> GetAllFixedDirections()
		{
			return await _dataContext.FixedDirections.ToListAsync();
		}

		public async Task<Direction> GetFixedDirection(string from, string to)
		{
			var dir = await _dataContext.FixedDirections.FirstOrDefaultAsync(x => x.From.ToLower() == from.ToLower() && x.To.ToLower() == to.ToLower());

			if (dir == null)
			{
				throw new Exception("No similar car brand found.");
			}

			return dir;
		}

		public async Task UpdateDirection(Direction direction)
		{
			var dir = await _dataContext.FixedDirections.FirstOrDefaultAsync(x => x.From.ToLower() == direction.From.ToLower() && x.To.ToLower() == direction.To.ToLower());

			if (dir == null)
			{
				throw new Exception("No similar car brand found.");
			}

			dir = direction;

			await _dataContext.SaveChangesAsync();
		}
	}
}
