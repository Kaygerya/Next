using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using MyNextMatch.AddressAPI;
using MyNextMatch.Core.Settings;
using MyNextMatch.Entities.Classes;
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
        private readonly TestServer _serverUser;
        private readonly TestServer _serverAddress;
        private readonly HttpClient _clientUser;
        private readonly HttpClient _clientAddress;

        public UserAddressTest()
        {
            var builderAddress = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>().UseConfiguration(new ConfigurationBuilder()
                .SetBasePath(@"C:\Users\Kaygerya\source\repos\Next\MyNextMatch.XUserAddressTests")
                .AddJsonFile("appsettingsAddress.json").Build());
            _serverAddress = new TestServer(builderAddress);

            _clientAddress = _serverAddress.CreateClient();
            _clientAddress.DefaultRequestHeaders.Accept.Clear();
            _clientAddress.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            var builderUser = new WebHostBuilder()
             .UseEnvironment("Development")
             .UseStartup<Startup>().UseConfiguration(new ConfigurationBuilder()
             .SetBasePath(@"C:\Users\Kaygerya\source\repos\Next\MyNextMatch.XUserAddressTests")
             .AddJsonFile("appsettingsUser.json").Build());
            _serverUser = new TestServer(builderUser);

            _clientUser = _serverUser.CreateClient();
            _clientUser.DefaultRequestHeaders.Accept.Clear();
            _clientUser.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        [Fact]
        public async Task GetUser()
        {
            ManagerSettings settings = new ManagerSettings();
            settings.UserUrl = _serverUser.BaseAddress +"api/user";
            UserAddressService userAddressService = new UserAddressService(settings);
            var users= userAddressService.GetAllUsers();

            users.Count().Should().BeGreaterThan(1);
        }

        
    }
}
