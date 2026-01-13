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

            // Foreign key only (no navigation property)
            builder.Property(x => x.UserId)
                   .IsRequired();

            builder.Property(x => x.TokenHash)
                   .IsRequired()
                   .HasMaxLength(512);

            builder.Property(x => x.ExpiresAt)
                   .IsRequired();
            builder.HasOne(user => user.User)
                .WithMany(token => token.RefreshTokens)
                .HasForeignKey(user => user.UserId);

            builder.Property(x => x.IsRevoked)
                   .HasDefaultValue(false);

            // Index for faster lookups
            builder.HasIndex(x => x.UserId);
        }
    }
}