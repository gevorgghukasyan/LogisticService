using LogisticService.Models.CalculationModels;

namespace LogisticService.Services.DirectionServices
{
	public interface IDirectionService
	{
		Task AddFixedDiraction(Direction direction);
		Task<Direction> GetFixedDirection(string from, string to);
		Task<IEnumerable<Direction>> GetAllFixedDirections();
		Task UpdateDirection(Direction direction);
		Task DeleteDirection(Direction direction);
	}
}
