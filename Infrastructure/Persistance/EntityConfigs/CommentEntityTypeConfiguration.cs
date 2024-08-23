using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistance.EntityConfigs;

public class CommentEntityTypeConfiguration
{
    public static void Configure(OwnedNavigationBuilder<Request, Comment> builder)
    {
        builder.ToTable("comments");
        builder.HasKey(c => c.Id);
        builder.WithOwner().HasForeignKey("requestId");
        builder
            .Property(c => c.Admin)
            .HasConversion(
                admin => admin.EmailAddress,
                address => new Admin(address))
            .HasMaxLength(128);
        builder
            .Property(c => c.Message)
            .HasMaxLength(512);
    }
}