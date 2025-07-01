using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.DAL.Core.Entities;

namespace ToDo.DAL.Core.Persistence.Configurations;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntityWithDates
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(k => k.ID);
        builder.Property(p => p.ID).HasColumnName(nameof(BaseEntity.ID));
        builder.Property(p => p.CreatedAt).HasColumnName(nameof(BaseEntityWithDates.CreatedAt)).IsRequired();
        builder.Property(p => p.UpdatedAt).HasColumnName(nameof(BaseEntityWithDates.UpdatedAt));
    }
}