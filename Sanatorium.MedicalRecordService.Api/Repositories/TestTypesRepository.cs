using Microsoft.EntityFrameworkCore;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.Api.Repositories
{
	public class TestTypesRepository : ITestTypesRepository
	{
		private readonly IMedicalRecordsServiceDbContext _context;
		public TestTypesRepository(IMedicalRecordsServiceDbContext context)
		{
			_context = context;
		}

		public async Task Create(TestType entity, CancellationToken cancellationToken)
		{
			await _context.TestTypes.AddAsync(entity,cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var type = await _context.TestTypes.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);
			if (type != null)
			{
				_context.TestTypes.Remove(type);
			}
		}

		public async Task<IEnumerable<TestType>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.TestTypes.ToListAsync(cancellationToken);
		}

		public async Task<TestType> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _context.TestTypes.FirstOrDefaultAsync(x=>x.Id == id, cancellationToken);

		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(TestType entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _context.TestTypes.Update(entity), cancellationToken);
		}
	}
}
