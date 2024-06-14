using LogisticService.Models.ContainerModels;

namespace LogisticService.Services.ContainerServices
{
	public interface IContainerService
	{
		Task<Container> GetContainer(bool IsClose);
		Task<IEnumerable<Container>> GetContainers();
		Task AddContainer(Container container);
	}
}
