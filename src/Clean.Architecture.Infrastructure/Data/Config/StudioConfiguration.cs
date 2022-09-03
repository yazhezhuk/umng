using Clean.Architecture.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Architecture.Infrastructure.Data.Config;

public class StudioConfiguration : IEntityTypeConfiguration<Studio>
{ 
    public void Configure(EntityTypeBuilder<Studio> builder)
  {
      builder.Property(p => p.Name)
          .HasMaxLength(100)
          .IsRequired();
  }
}
