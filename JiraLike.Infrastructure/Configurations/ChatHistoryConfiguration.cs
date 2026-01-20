using JiraLike.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JiraLike.Infrastructure.Configurations
{
    public class ChatHistoryEntityConfiguration : IEntityTypeConfiguration<ChatHistoryEntity>
    {
        public void Configure(EntityTypeBuilder<ChatHistoryEntity> builder)
        {
            builder.ToTable("ChatHistory");

            builder.HasKey(ch => ch.Id);

            builder.Property(ch => ch.Question).IsRequired();
            builder.Property(ch => ch.Response).IsRequired();

            builder.HasQueryFilter(ch => !ch.IsDeleted);
        }
    }
}
