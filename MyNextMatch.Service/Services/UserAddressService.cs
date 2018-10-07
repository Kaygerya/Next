using MyNextMatch.Core.Settings;
using MyNextMatch.Entities.Classes;
using MyNextMatch.Service.Abstract;
using MyNextMatch.Service.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MyNextMatch.Service.Services
{
    public class UserAddressService : IUserAddressService
    {
        private ManagerSettings _settings;
        public UserAddressService(ManagerSettings settings)
        {
            _settings = settings;
        }

        public List<User> GetAllUsers()
        {
            var request = (HttpWebRequest)WebRequest.Create(_settings.UserUrl);
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<List<User>>(responseString);
        }

        public void Insert(User user)
        {
            var request = (HttpWebRequest)WebRequest.Create(_settings.UserUrl);

            var postData = JsonConvert.SerializeObject(user);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var resultUser = JsonConvert.DeserializeObject<User>(responseString);
            user.Errors = resultUser.Errors;
        }

        public void UpdateUserAddress(int userId, Address address)
        {
            var request = (HttpWebRequest)WebRequest.Create(_settings.AddressUrl +"/"+ userId);

            var postData = JsonConvert.SerializeObject(address);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            var resultAddress = JsonConvert.DeserializeObject<Address>(responseString);
            address.Errors = resultAddress.Errors;
        }
    }
}
