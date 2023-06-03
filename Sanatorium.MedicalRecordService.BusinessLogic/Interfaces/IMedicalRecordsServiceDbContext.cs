using Microsoft.EntityFrameworkCore;

using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.Interfaces
{
	public interface IMedicalRecordsServiceDbContext
	{
		public DbSet<Diagnosis> Diagnoses { get; set; }
		public DbSet<PatientDaignosis> PatientDaignoses { get; set; }
		public DbSet<TestReffal> TestReffals { get; set;}
		public DbSet<TestResult> TestResults { get; set; }
		public DbSet<TestType> TestTypes { get; set; }
		public DbSet<ProcedureReffal> ProcedureReffals { get; set; }
		public DbSet<ProcedureType> ProcedureTypes { get; set; }
		public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
