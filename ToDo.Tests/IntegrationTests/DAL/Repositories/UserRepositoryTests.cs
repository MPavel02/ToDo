using FluentAssertions;
using ToDo.DAL.Repositories;
using ToDo.Domain.Entities;
using ToDo.Domain.ValueObjects;
using ToDo.Tests.Shared;

namespace ToDo.Tests.IntegrationTests.DAL.Repositories;

public class UserRepositoryTests
{
    [Fact]
    public async Task AddAsync_ExistingUser_ReturnsUserWithNote()
    {
        // Arrange
        await using var context = TestHelper.CreateContext();
        var user = new User(Guid.NewGuid(), Username.From("TestName"), DateTime.UtcNow);
        user.AddNote("Новая заметка", "Детали заметки");

        var userRepository = new UserRepository(context);
        
        // Act
        await userRepository.AddAsync(user);
        
        var getUserResult = await userRepository.GetByIDAsync(user.ID);
        
        // Assert
        getUserResult.Should().Be(user);
        getUserResult.Notes.Should().HaveCount(1);
    }
    
    [Fact]
    public async Task GetAllAsync_ExistingUsers_ReturnsUsers()
    {
        // Arrange
        await using var context = TestHelper.CreateContext();
        var user1 = new User(Guid.NewGuid(), Username.From("TestName1"), DateTime.UtcNow);
        var user2 = new User(Guid.NewGuid(), Username.From("TestName2"), DateTime.UtcNow);

        var userRepository = new UserRepository(context);
        
        // Act
        await userRepository.AddAsync(user1);
        await userRepository.AddAsync(user2);
        
        var getUsersResult = await userRepository.GetAllAsync();
        
        // Assert
        getUsersResult.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task UpdateAsync_ExistingUser_ReturnsUpdatedUser()
    {
        // Arrange
        await using var context = TestHelper.CreateContext();
        var user = new User(Guid.NewGuid(), Username.From("TestName1"), DateTime.UtcNow);
        var updatedName = Username.From("TestName2");

        var userRepository = new UserRepository(context);
        
        // Act
        await userRepository.AddAsync(user);
        
        var getUserResult = await userRepository.GetByIDAsync(user.ID);
        
        getUserResult?.ChangeName(updatedName);
        
        await userRepository.UpdateAsync(user);
        
        var getUpdatedUserResult = await userRepository.GetByIDAsync(user.ID);
        
        // Assert
        getUpdatedUserResult?.Name.Should().Be(updatedName);
        getUpdatedUserResult?.UpdatedAt.Should().NotBeNull();
    }
    
    [Fact]
    public async Task DeleteAsync_ExistingUser_DeleteUser()
    {
        // Arrange
        await using var context = TestHelper.CreateContext();
        var user1 = new User(Guid.NewGuid(), Username.From("TestName1"), DateTime.UtcNow);
        var user2 = new User(Guid.NewGuid(), Username.From("TestName2"), DateTime.UtcNow);

        var userRepository = new UserRepository(context);
        
        // Act
        await userRepository.AddAsync(user1);
        await userRepository.AddAsync(user2);
        
        await userRepository.DeleteAsync(user1);
        
        var getUserResult = await userRepository.GetByIDAsync(user2.ID);
        var getUsersResult = await userRepository.GetAllAsync();
        
        // Assert
        getUsersResult.Should().HaveCount(1);
        getUserResult.Should().NotBeNull();
        getUserResult.Should().Be(user2);
    }
}