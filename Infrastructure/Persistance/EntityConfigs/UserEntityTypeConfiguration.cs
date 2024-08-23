using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.EntityConfigs;

public class UserEntityTypeConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users_info");
        builder.HasKey(u => u.EmailAddress);
        builder
            .Property(u => u.EmailAddress)
            .HasMaxLength(128)
            .IsRequired();
        builder
            .Property(u => u.AvatarImgLink)
            .HasMaxLength(32);
        builder
            .Property(u => u.Nickname)
            .HasMaxLength(32);
        builder
            .Property(u => u.FirstName)
            .HasMaxLength(32);
        builder
            .Property(u => u.MiddleName)
            .HasMaxLength(32);
        builder
            .Property(u => u.LastName)
            .HasMaxLength(32);
        builder
            .Property(u => u.Course)
            .HasMaxLength(32);
        builder
            .Property(u => u.BannedBy)
            .HasMaxLength(128);
    }
}
