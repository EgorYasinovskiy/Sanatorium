using Microsoft.EntityFrameworkCore;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.Api.Repositories
{
	public class TestResultsRepository : ITestResultsRepository
	{

		private readonly IMedicalRecordsServiceDbContext _context;
		public TestResultsRepository(IMedicalRecordsServiceDbContext context)
		{
			_context = context;
		}

		public async Task Create(TestResult entity, CancellationToken cancellationToken)
		{
			await _context.TestResults.AddAsync(entity,cancellationToken);
		}

		public async Task DeleteById(Guid id, CancellationToken cancellationToken)
		{
			var res = await _context.TestResults.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);
			if (res != null)
			{
				_context.TestResults.Remove(res);
			}
		}

		public async Task<IEnumerable<TestResult>> GetAll(CancellationToken cancellationToken)
		{
			return await _context.TestResults.ToListAsync(cancellationToken);
		}

		public async Task<TestResult> GetById(Guid id, CancellationToken cancellationToken)
		{
			return await _context.TestResults.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);

		}

		public async Task SaveChanges(CancellationToken cancellationToken)
		{
			await _context.SaveChangesAsync(cancellationToken);
		}

		public async Task Update(TestResult entity, CancellationToken cancellationToken)
		{
			await Task.Run(() => _context.TestResults.Update(entity),cancellationToken);
		}
	}
}
