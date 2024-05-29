namespace LogisticService.Mapper
{
	public interface IMapper<TIn, TOut>
	{
		public TOut Map(TIn input);
	}
}
