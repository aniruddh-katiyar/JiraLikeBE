namespace JiraLike.Infrastructure.Configurations
{
    using JiraLike.Domain.Token;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RefreshTokenEntityConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenEntity> builder)
        {
            builder.ToTable("RefreshTokens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                   .IsRequired();

            builder.Property(x => x.TokenHash)
                   .IsRequired()
                   .HasMaxLength(512);

            builder.Property(x => x.ExpiresAt)
                   .IsRequired();

            builder.HasOne(rt => rt.User)
                   .WithMany(u => u.RefreshTokens)
                   .HasForeignKey(rt => rt.UserId)
                   .IsRequired(); // still required

            builder.Property(x => x.IsRevoked)
                   .HasDefaultValue(false);

            // Index for faster lookups
            builder.HasIndex(x => x.UserId);

            // Matching query filter to align with UserEntity’s filter
            builder.HasQueryFilter(rt => !rt.User.IsDeleted);
        }
    }
}