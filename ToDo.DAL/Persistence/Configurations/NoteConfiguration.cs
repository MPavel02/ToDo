using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;

namespace ToDo.DAL.Persistence.Configurations;

/// <summary>
/// Конфигурация для модели <see cref="Note"/>.
/// </summary>
internal class NoteConfiguration : BaseEntityConfiguration<Note>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<Note> entity)
    {
        base.Configure(entity);

        entity.ToTable("Notes");
        
        entity.Property(e => e.Title)
            .HasMaxLength(64)
            .IsRequired();
        
        entity.Property(e => e.Details)
            .HasMaxLength(256)
            .IsRequired();

        entity.HasOne(o => o.User)
            .WithMany()
            .HasForeignKey(note => note.UserID)
            .IsRequired();
    }
}