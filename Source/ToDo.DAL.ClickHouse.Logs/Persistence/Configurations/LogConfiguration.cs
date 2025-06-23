using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.DAL.ClickHouse.Logs.Persistence.Configurations;

/// <summary>
/// Конфигурация для модели <see cref="LogEntry"/>.
/// </summary>
internal class LogConfiguration : IEntityTypeConfiguration<LogEntry>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<LogEntry> entity)
    {
        entity.ToTable("Logs");
        
        entity.HasKey(k => k.ID);
        entity.Property(p => p.ID).HasColumnName(nameof(BaseEntity.ID));
        entity.Property(p => p.Timestamp).HasColumnName(nameof(LogEntry.Timestamp))
            .HasColumnType("DateTime")
            .IsRequired();
        
        entity.Property(p => p.Message)
            .IsRequired();
    }
}