using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using MyNextMatch.AddressAPI;
using MyNextMatch.Entities.Classes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace MyNextMatch.XUserTests
{
    public class AddressTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public AddressTest()
        {
            var builder = new WebHostBuilder()
        .UseEnvironment("Development")
        .UseStartup<Startup>().UseConfiguration(new ConfigurationBuilder()
        .SetBasePath(@"C:\Users\Kaygerya\source\repos\Next\MyNextMatch.XAddressTests")
        .AddJsonFile("appsettings.json").Build());

            _server = new TestServer(builder);

            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Fact]
        public async Task GetAddress()
        {
            var response = await _client.GetAsync("/api/Address");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var address = JsonConvert.DeserializeObject<IEnumerable<Address>>(responseString);
            address.Count().Should().BeGreaterThan(1);
        }

        [Fact]
        public async Task PostAddress()
        {
            Address address = new Address();
            address.AddressLine = "Merkez";
            address.Owner = 1;
            address.OwnerType = "T";
            address.PostCode = "5000";
            var response = await _client.PostAsJsonAsync("/api/address/1", address);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var resultAddress = JsonConvert.DeserializeObject<Address>(responseString);
            resultAddress.AddressId.Should().BeGreaterThan(1);
        }

        [Fact]
        public async Task PutAddress()
        {
            Address address = new Address();
            address.AddressId = 10;
            address.AddressLine = "Merkez";
            address.Owner = 1;
            address.OwnerType = "T";
            address.PostCode = "5000";
            var response = await _client.PutAsJsonAsync("/api/address/1", address);

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var resultAddress = JsonConvert.DeserializeObject<Address>(responseString);
            resultAddress.Owner.Should().Be(1);
            resultAddress.AddressId.Should().BeGreaterThan(1);
        }
    }
}
