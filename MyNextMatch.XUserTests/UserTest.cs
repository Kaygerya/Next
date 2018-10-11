using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using MyNextMatch.Entities.Classes;
using MyNextMatch.UserAPI;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace MyNextMatch.XUserTests
{
    public class UserTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UserTest()
        {
            var builder = new WebHostBuilder()
        .UseEnvironment("Development")
        .UseStartup<Startup>().UseConfiguration(new ConfigurationBuilder()
        .SetBasePath(@"C:\Users\Kaygerya\source\repos\Next\MyNextMatch.XUserTests")
        .AddJsonFile("appsettings.json").Build());

            _server = new TestServer(builder);

            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Fact]
        public async Task GetUsers()
        {
            var response = await _client.GetAsync("/api/User");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<IEnumerable<User>>(responseString);
            users.Count().Should().BeGreaterThan(10);
        }

        [Fact]
        public async Task PostUser()
        {
            User user = new User();
            user.Name = "NameTest";
            user.Surname = "SurnameTest";
            user.Email = "Test@test.com";
            var response = await _client.PostAsJsonAsync("/api/User", user);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var resultUser = JsonConvert.DeserializeObject<User>(responseString);
            resultUser.UserId.Should().BeGreaterThan(1);
            resultUser.Name.Should().Be("NameTest");
        }
    }
}
