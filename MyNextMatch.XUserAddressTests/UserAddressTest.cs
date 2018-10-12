using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Moq;
using MyNextMatch.AddressAPI;
using MyNextMatch.API.Controllers;
using MyNextMatch.Core.Settings;
using MyNextMatch.Entities.Base;
using MyNextMatch.Entities.Classes;
using MyNextMatch.Service.Abstract;
using MyNextMatch.Service.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace MyNextMatch.XUserTests
{
    public class UserAddressTest
    {
        private readonly ManagerSettings _managerSettings;
        public UserAddressTest()
        {
            _managerSettings = new ManagerSettings();
           
        }

        [Fact]
        public async Task GetUser()
        {
            var _userAddressService = new Mock<IUserAddressService>();
            List<User> mockedUsers = new List<User>();
            mockedUsers.Add(new User() { Email = "test@test.com", Name = "Test", Surname = "TestSurname", UserId = 1 });
            mockedUsers.Add(new User() { Email = "test2@test.com", Name = "Test2", Surname = "Test2Surname", UserId =2 });
            _userAddressService.Setup(p => p.GetAllUsers()).Returns(mockedUsers);

            UserController userController= new UserController(_userAddressService.Object);
            var result = userController.Get().Value.Count();
            Assert.True( result.Equals(2));
        }

        [Fact]
        public async Task PostUser()
        {
            var _userAddressService = new Mock<IUserAddressService>();
            User mockedUser = new User() { Email = "test@test.com", Name = "Test", Surname = "TestSurname", UserId = 1 };
            _userAddressService.Setup(p => p.InsertUser(mockedUser)).Returns(mockedUser);

            UserController userController = new UserController(_userAddressService.Object);
            var result =userController.Post(mockedUser).Value;
            Assert.True(result.IsSuccess);
        }
        [Fact]
        public async Task PutUserAddress()
        {
            var _userAddressService = new Mock<IUserAddressService>();
            UserAddress mockedUserAddress = new UserAddress(); //new User() { Email = "test@test.com", Name = "Test", Surname = "TestSurname", UserId = 1 };
            _userAddressService.Setup(p => p.InsertUser(mockedUserAddress.User)).Returns(mockedUserAddress.User);
            _userAddressService.Setup(p => p.InsertAddress(mockedUserAddress.Address)).Returns(mockedUserAddress.Address);

            UserAddressController userAddressController = new UserAddressController(_userAddressService.Object);
            var okResult = Assert.IsType<OkObjectResult>(userAddressController.Put(1, mockedUserAddress).Result);

            Assert.True(okResult.StatusCode == 200);
        }

        [Fact]
        public async Task PutUserAddressUserFail()
        {
            var _userAddressService = new Mock<IUserAddressService>();
            UserAddress mockedUserAddress = new UserAddress();
            mockedUserAddress.User.Errors.Add("Error");
            _userAddressService.Setup(p => p.InsertUser(mockedUserAddress.User)).Returns(mockedUserAddress.User);
            _userAddressService.Setup(p => p.InsertAddress(mockedUserAddress.Address)).Returns(mockedUserAddress.Address);

            UserAddressController userAddressController = new UserAddressController(_userAddressService.Object);
            var okResult = Assert.IsType<NotFoundResult>(userAddressController.Put(1, mockedUserAddress).Result);

            Assert.True(okResult.StatusCode == 404);
        }

        [Fact]
        public async Task PutUserAddressAddressFail()
        {
            var _userAddressService = new Mock<IUserAddressService>();
            UserAddress mockedUserAddress = new UserAddress();
            mockedUserAddress.Address.Errors.Add("Error");
            _userAddressService.Setup(p => p.InsertUser(mockedUserAddress.User)).Returns(mockedUserAddress.User);
            _userAddressService.Setup(p => p.InsertAddress(mockedUserAddress.Address)).Returns(mockedUserAddress.Address);

            UserAddressController userAddressController = new UserAddressController(_userAddressService.Object);
            var okResult = Assert.IsType<NotFoundObjectResult>(userAddressController.Put(1, mockedUserAddress).Result);

            Assert.True(okResult.StatusCode == 404);
        }



    }
}
