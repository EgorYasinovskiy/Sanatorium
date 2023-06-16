using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.Api
{
	public class TestReffalEntityConfig : IEntityTypeConfiguration<TestReffal>
	{
		public void Configure(EntityTypeBuilder<TestReffal> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.HasOne(x => x.TestResult).WithOne(x => x.TestReffal).HasForeignKey<TestResult>(x=>x.TestReffalID);
		}
	}
}
