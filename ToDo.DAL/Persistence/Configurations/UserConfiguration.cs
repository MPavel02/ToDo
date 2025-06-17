using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Domain.Entities;
using ToDo.Domain.ValueObjects;

namespace ToDo.DAL.Persistence.Configurations;

/// <summary>
/// Конфигурация для модели <see cref="User"/>.
/// </summary>
internal class UserConfiguration : BaseEntityConfiguration<User>
{
    /// <inheritdoc />
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.ToTable("Users");
        
        builder.HasMany(m => m.Notes)
            .WithOne(o => o.User)
            .HasForeignKey(note => note.UserID)
            .OnDelete(DeleteBehavior.Cascade);

        builder.OwnsOne(user => user.Name, nameBuilder => nameBuilder
            .Property(name => name.Value)
                .HasColumnName(nameof(User.Name))
                .HasMaxLength(Username.MaxLength)
                .IsRequired());
    }
}