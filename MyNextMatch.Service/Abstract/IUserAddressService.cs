using MyNextMatch.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.Service.Abstract
{
    public interface IUserAddressService
    {
        List<User> GetAllUsers();
        void Insert(User user);
        void UpdateUserAddress(int userId, Address address);
    }
}
