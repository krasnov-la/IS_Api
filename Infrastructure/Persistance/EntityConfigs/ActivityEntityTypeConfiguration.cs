using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.EntityConfigs;

public class ActivityEntityTypeConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("activities");

        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Id);

        builder
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(128);

        builder
            .Property(a => a.Admin)
            .HasConversion(
                admin => admin.EmailAddress,
                address => new Admin(address))
            .IsRequired()
            .HasMaxLength(128);

        builder
            .Property(a => a.Start)
            .IsRequired();

        builder
            .Property(a => a.Finish)
            .IsRequired();

        builder
            .Property(a => a.Preview)
            .HasConversion(
                image => image.Guid,
                guid => new Image(guid))
            .IsRequired();
        
        builder
            .Property(a => a.Link)
            .HasMaxLength(128)
            .IsRequired();
    }
}
