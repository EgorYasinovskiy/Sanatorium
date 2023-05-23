namespace Sanatorium.Common
{
	public interface IRepositoryBase<T> where T: class
	{
		public Task Create(T entity, CancellationToken cancellationToken);
		public Task<T> GetById(Guid id, CancellationToken cancellationToken);
		public Task<IEnumerable<T>> GetAll(CancellationToken cancellationToken);
		public Task DeleteById(Guid id, CancellationToken cancellationToken);
		public Task Update(T entity, CancellationToken cancellationToken);
		public Task SaveChanges(CancellationToken cancellationToken);
	}
}
