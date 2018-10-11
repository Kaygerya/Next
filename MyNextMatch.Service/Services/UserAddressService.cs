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

        public User InsertUser(User user)
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
            User resultUser = new User();
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resultUser = JsonConvert.DeserializeObject<User>(responseString);
            }
            catch
            {
                resultUser.Errors.Add("Error");
            }
            return resultUser;
        }

        public Address InsertAddress( Address address)
        {
            var request = (HttpWebRequest)WebRequest.Create(_settings.AddressUrl + "/"+ address.Owner);

            var postData = JsonConvert.SerializeObject(address);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            Address resultAddress = new Address();
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resultAddress = JsonConvert.DeserializeObject<Address>(responseString);
            }
            catch(Exception ex)
            {
                resultAddress.Errors.Add("Error");
            }
            return resultAddress;
        }

        public Address UpdateAddress(Address address)
        {
            var request = (HttpWebRequest)WebRequest.Create(_settings.AddressUrl + "/" + address.Owner);

            var postData = JsonConvert.SerializeObject(address);
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            Address resultAddress = new Address();
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                resultAddress = JsonConvert.DeserializeObject<Address>(responseString);
            }
            catch (Exception ex)
            {
                resultAddress.Errors.Add("Error");
            }
            return resultAddress;
        }



        public HttpStatusCode DeleteUser(int userId)
        {
            var request = (HttpWebRequest)WebRequest.Create(_settings.UserUrl +"/" + userId);
            request.Method = "DELETE";
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return response.StatusCode;
        }

       
    }
}
