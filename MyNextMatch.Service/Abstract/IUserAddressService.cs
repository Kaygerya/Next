using MyNextMatch.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MyNextMatch.Service.Abstract
{
    public interface IUserAddressService
    {
        List<User> GetAllUsers();
        User InsertUser(User user);
        Address InsertAddress(Address address);
        Address UpdateAddress(Address address)
        HttpStatusCode DeleteUser(int userId);
    }
}
