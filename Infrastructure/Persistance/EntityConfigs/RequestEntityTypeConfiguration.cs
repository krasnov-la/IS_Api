using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.EntityConfigs;

public class RequestEntityTypeConfiguration
    : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("verification_requests");
        builder.HasKey(r => r.Id);
        builder
            .Property(r => r.Student)
            .HasConversion(
                student => student.EmailAddress,
                address => new Student(address))
            .HasMaxLength(128);
        builder
            .OwnsMany(
                r => r.Images,
                b => {
                    b.ToTable("images");
                    b.HasKey(i => i.Guid);
                    });
        builder
            .Property(r => r.EventName)
            .HasMaxLength(128);
        builder
            .Property(r => r.Description)
            .HasMaxLength(512);
        builder
            .Property(r => r.CreatedAt);
        builder
            .Property(r => r.Status)
            .HasConversion<string>();
        builder
            .OwnsOne(
                r => r.Achievement,
                AchievementEntityTypeConfiguration.Configure);
        builder
            .OwnsOne(
                r => r.Comment,
                CommentEntityTypeConfiguration.Configure);
    }
}
