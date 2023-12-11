using backend.DTOs;
using backend.Models;
using backend.Repositories;
using backend.Services;
using Moq;
using AutoMapper;
using Xunit;
// using Xunit.Abstractions;

namespace backend.Testing
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _userService = new UserService(_userRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void GetNumberOfUsers_ReturnsCorrectNumber() // This is useless unless we plug in a real instance of UserRepository
        {
            // Arrange
            int expectedNumberOfUsers = 5;
            _userRepositoryMock.Setup(ur => ur.GetNumberOfUsers()).Returns(expectedNumberOfUsers);

            // Act
            int actualNumberOfUsers = _userService.GetNumberOfUsers();

            // Assert
            Assert.Equal(expectedNumberOfUsers, actualNumberOfUsers);
        }

        [Fact]
        public async Task GetUsersAsync_ReturnsMappedUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new() { 
                    Id = 1, 
                    Email = "test1@test.com", 
                    FirstName = "Test", 
                    LastName = "One", 
                    Bio = "Bio One", 
                    Country = "Country One", 
                    PersonalLink = "Link One",
                    ProfilePictureLink = "ProfilePictureLink One"
                },
                new() { 
                    Id = 2, 
                    Email = "test2@test.com", 
                    FirstName = "Test", 
                    LastName = "Two", 
                    Bio = "Bio Two", 
                    Country = "Country Two", 
                    PersonalLink = "Link Two",
                    ProfilePictureLink = "ProfilePictureLink One"
                }
            };

            var userDTOs = new List<UserDTO>
            {
                new(1, "test1@test.com", "Test", "One", "Bio One", "Country One", "Link One", UserRole.Admin, "link"),
                new(2, "test2@test.com", "Test", "Two", "Bio Two", "Country Two", "Link Two", UserRole.Admin,"link")
            };

            _userRepositoryMock.Setup(repo => repo.GetUsersAsync()).ReturnsAsync(users);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<UserDTO>>(users)).Returns(userDTOs);

            // Act
            var result = await _userService.GetUsersAsync();

            // Assert
            Assert.Equal(userDTOs, result);
        }

        [Fact]
        public async Task GetUserByIdAsync_UserExists_ReturnsUser()
        {
            // Arrange
            var expectedUser = new UserDTO(1, "test1@test.com", "Test", "One", "Bio One", "Country One", "Link One", UserRole.Admin,"Link");
            _userRepositoryMock.Setup(ur => ur.GetUserByIdAsync(expectedUser.Id))
                .ReturnsAsync(new User 
                { 
                    Id = expectedUser.Id, 
                    Email = expectedUser.Email,
                    FirstName = expectedUser.FirstName,
                    LastName = expectedUser.LastName,
                    Bio = expectedUser.Bio,
                    Country = expectedUser.Country,
                    PersonalLink = expectedUser.Link,
                    ProfilePictureLink = expectedUser.ProfilePictureLink
                });
            _mapperMock.Setup(m => m.Map<UserDTO>(It.IsAny<User>())).Returns(expectedUser);

            // Act
            var user = await _userService.GetUserByIdAsync(expectedUser.Id);

            // Assert
            Assert.Equal(expectedUser.Id, user.Id);
            Assert.Equal(expectedUser.Email, user.Email);
            Assert.Equal(expectedUser.FirstName, user.FirstName);
            Assert.Equal(expectedUser.LastName, user.LastName);
            Assert.Equal(expectedUser.Bio, user.Bio);
            Assert.Equal(expectedUser.Country, user.Country);
            Assert.Equal(expectedUser.Link, user.Link);
        }


        [Fact]
        public async Task AddUserAsync_AddsUser()
        {
            // Arrange
            var userDto = new UserRegisterationDTO("test1@test.com", "Test", "One", "Bio One", "Country One", "Link One", UserRole.Admin);
            _userRepositoryMock.Setup(ur => ur.AddUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            // Act
            await _userService.AddUserAsync(userDto);

            // Assert
            _userRepositoryMock.Verify(ur => ur.AddUserAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_UpdatesUser()
        {
            // Arrange
            var userDto = new UserDTO(1, "test1@test.com", "Test", "One", "Bio One", "Country One", "Link One", UserRole.Admin, "Link");
            _userRepositoryMock.Setup(ur => ur.GetUserByIdAsync(userDto.Id)).ReturnsAsync(new User());
            _userRepositoryMock.Setup(ur => ur.UpdateUserAsync(It.IsAny<User>())).Returns(Task.CompletedTask);

            // Act
            await _userService.UpdateUserAsync(userDto);

            // Assert
            _userRepositoryMock.Verify(ur => ur.UpdateUserAsync(It.IsAny<User>()), Times.Once);
        }
    }
}
