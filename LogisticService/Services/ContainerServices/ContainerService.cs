using LogisticService.Data;
using LogisticService.Models.ContainerModels;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Services.ContainerServices
{
	public class ContainerService : IContainerService
	{
		private readonly DataContext _dataContext;

		public ContainerService(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public async Task AddContainer(Container container)
			=> await _dataContext.Containers.AddAsync(container);

		public async Task<Container> GetContainer(bool IsClose)
			=> await _dataContext.Containers.FirstOrDefaultAsync(x => x.InClose == IsClose);

		public async Task<IEnumerable<Container>> GetContainers()
			=> await _dataContext.Containers.ToListAsync();
	}
}
