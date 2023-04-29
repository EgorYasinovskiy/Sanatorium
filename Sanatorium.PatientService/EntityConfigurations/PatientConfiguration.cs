using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sanatorium.PatientService.DataModel;

namespace Sanatorium.PatientService.EntityConfigurations
{
	public class PatientConfiguration : IEntityTypeConfiguration<Patient>
	{
		public void Configure(EntityTypeBuilder<Patient> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.Id).IsUnique();
			builder.Property(x => x.FirstName).HasMaxLength(64).IsRequired();
			builder.Property(x => x.LastName).HasMaxLength(64).IsRequired();
			builder.Property(x => x.MiddleName).HasMaxLength(64).IsRequired();
			builder.Property(x => x.PhoneNumber).HasMaxLength(16).IsRequired();
			builder.Property(x => x.Discharged).IsRequired().HasDefaultValue(true);
		}
	}
}
