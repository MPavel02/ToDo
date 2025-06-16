using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.DAL.Persistence.Configurations;

internal class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(k => k.ID);
        builder.Property(p => p.ID).HasColumnName(nameof(BaseEntity.ID));
        builder.Property(p => p.CreatedAt).HasColumnName(nameof(BaseEntity.CreatedAt)).IsRequired();
        builder.Property(p => p.UpdatedAt).HasColumnName(nameof(BaseEntity.UpdatedAt));
    }
}