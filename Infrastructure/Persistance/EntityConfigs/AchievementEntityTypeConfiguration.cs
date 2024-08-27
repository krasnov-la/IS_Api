using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.EntityConfigs;

public class AchievementEntityTypeConfiguration
{
    public static void Configure(OwnedNavigationBuilder<Request, Achievement> builder)
    {
        builder.ToTable("achievements");
        builder
            .HasKey(a => a.Id);
        builder
            .Property(a => a.Id)
            .ValueGeneratedOnAdd();
        builder.WithOwner().HasForeignKey("requestId");
        builder
            .Property(a => a.Admin)
            .HasConversion(
                admin => admin.EmailAddress,
                address => new Admin(address))
            .HasMaxLength(128);
        builder
            .Property(a => a.Score);
    }
}
