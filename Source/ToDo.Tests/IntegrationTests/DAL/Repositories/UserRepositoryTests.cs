using FluentAssertions;
using ToDo.DAL.Repositories;
using ToDo.Domain.DomainEntities;
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
        var user = UserDomain.Create(Username.From("TestName"), string.Empty);
        user.AddNote("Новая заметка", "Детали заметки");

        var userRepository = new UserRepository(context);
        
        // Act
        await userRepository.AddAsync(user);
        
        var getUserResult = await userRepository.GetByIDAsync(user.ID);
        
        // Assert
        getUserResult.Should().BeEquivalentTo(user); 
        getUserResult.Notes.Should().HaveCount(1);
    }
    
    [Fact]
    public async Task GetByNameAsync_ExistingUser_ReturnsUser()
    {
        // Arrange
        var username = Username.From("TestName");
        
        await using var context = TestHelper.CreateContext();
        var user1 = UserDomain.Create(username, string.Empty);

        var userRepository = new UserRepository(context);
        
        // Act
        await userRepository.AddAsync(user1);
        
        var getUsersResult = await userRepository.GetByNameAsync(username);
        
        // Assert
        getUsersResult.Should().NotBeNull();
    }
    
    [Fact]
    public async Task GetAllAsync_ExistingUsers_ReturnsUsers()
    {
        // Arrange
        await using var context = TestHelper.CreateContext();
        var user1 = UserDomain.Create(Username.From("TestName1"), string.Empty);
        var user2 = UserDomain.Create(Username.From("TestName2"), string.Empty);

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
        var user = UserDomain.Create(Username.From("TestName1"), string.Empty);
        var updatedName = Username.From("TestName2");

        var userRepository = new UserRepository(context);
        
        // Act
        await userRepository.AddAsync(user);
        
        var getUserResult = await userRepository.GetByIDAsync(user.ID);

        if (getUserResult is null)
            return;
        
        getUserResult.ChangeName(updatedName);
        
        await userRepository.UpdateAsync(getUserResult);
        
        var getUpdatedUserResult = await userRepository.GetByIDAsync(user.ID);
        
        // Assert
        getUpdatedUserResult?.Username.Should().BeEquivalentTo(updatedName);
        getUpdatedUserResult?.UpdatedAt.Should().NotBeNull();
    }
    
    [Fact]
    public async Task DeleteAsync_ExistingUser_DeleteUser()
    {
        // Arrange
        await using var context = TestHelper.CreateContext();
        var user1 = UserDomain.Create(Username.From("TestName1"), string.Empty);
        var user2 = UserDomain.Create(Username.From("TestName2"), string.Empty);

        var userRepository = new UserRepository(context);
        
        // Act
        await userRepository.AddAsync(user1);
        await userRepository.AddAsync(user2);
        
        await userRepository.DeleteAsync(user1.ID);
        
        var getUserResult = await userRepository.GetByIDAsync(user2.ID);
        var getUsersResult = await userRepository.GetAllAsync();
        
        // Assert
        getUsersResult.Should().HaveCount(1);
        getUserResult.Should().NotBeNull();
        getUserResult.Should().BeEquivalentTo(user2);
    }
}