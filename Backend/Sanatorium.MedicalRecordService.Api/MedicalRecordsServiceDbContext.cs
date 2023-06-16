using Microsoft.EntityFrameworkCore;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.Api
{
	public class MedicalRecordsServiceDbContext : DbContext, IMedicalRecordsServiceDbContext
	{
		public DbSet<Diagnosis> Diagnoses { get; set; }
		public DbSet<PatientDaignosis> PatientDaignoses { get; set; }
		public DbSet<TestReffal> TestReffals { get; set; }
		public DbSet<TestResult> TestResults { get; set; }
		public DbSet<TestType> TestTypes { get; set; }
		public DbSet<ProcedureReffal> ProcedureReffals { get; set; }
		public DbSet<ProcedureType> ProcedureTypes { get; set; }

		public MedicalRecordsServiceDbContext(DbContextOptions<MedicalRecordsServiceDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration<TestReffal>(new TestReffalEntityConfig());
		}
	}
}
