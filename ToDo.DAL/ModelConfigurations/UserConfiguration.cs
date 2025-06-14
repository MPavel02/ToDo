using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.DAL.ModelConfigurations;

/// <summary>
/// Конфигурация для модели <see cref="User"/>.
/// </summary>
internal class UserConfiguration : BaseEntityConfiguration<User>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<User> entity)
    {
        base.Configure(entity);

        entity.ToTable("Users");
        
        entity.Property(e => e.Name)
            .HasMaxLength(64)
            .IsRequired();

        entity.HasMany(m => m.Notes)
            .WithOne()
            .HasForeignKey(note => note.UserID)
            .IsRequired();
    }
}