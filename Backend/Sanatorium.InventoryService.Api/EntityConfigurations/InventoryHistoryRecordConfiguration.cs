using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Sanatorium.InventoryService.Model;

namespace Sanatorium.InventoryService.Api.EntityConfigurations
{
	public class InventoryHistoryRecordConfiguration : IEntityTypeConfiguration<InventoryHistoryRecord>
	{
		public void Configure(EntityTypeBuilder<InventoryHistoryRecord> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasIndex(x => x.Id);
		}
	}
}
