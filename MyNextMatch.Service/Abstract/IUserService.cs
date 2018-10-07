using MyNextMatch.Entities.Base;
using MyNextMatch.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.Service.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int userId);
        void Insert(User user);
        void Update(User user);
        void Delete(int userId);
    }
}
