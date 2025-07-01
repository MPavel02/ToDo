using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.DAL.Core.Persistence.Configurations;
using ToDo.DAL.Entities;

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

        builder.Property(user => user.Username)
            .HasColumnName(nameof(User.Username))
            .HasMaxLength(64)
            .IsRequired();
        
        builder.HasIndex(user => user.Username)
            .IsUnique();

        builder.Property(user => user.PasswordHash)
            .IsRequired();
        
        builder.Property(user => user.Role)
            .IsRequired();
    }
}