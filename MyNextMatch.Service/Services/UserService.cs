using MyNextMatch.DataAccess.Abstract;
using MyNextMatch.Entities.Base;
using MyNextMatch.Entities.Classes;
using MyNextMatch.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.Service.Services
{
    public class UserService : IUserService
    {
        private IUserDAL _userData { get; set; }

        public UserService(IUserDAL userData)
        {
            this._userData = userData;
        }

        public void Delete(int userId)
        {
            if (userId == 0)
                throw new System.InvalidOperationException("userId is 0");

            var user = GetById(userId);
            if (user == null)
                throw new System.InvalidOperationException("user is null");

            try
            {
                _userData.Delete(user);
            }
            catch (Exception ex)
            {
                user.Errors.Add(ex.Message);
            }
        }

        public List<User> GetAll()
        {
            return _userData.GetList();
        }

        public User GetById(int userId)
        {
            if (userId == 0)
                throw new System.InvalidOperationException("userId 0");

            return _userData.Get(u => u.UserId == userId);
        }

        public void Insert(User user)
        {
            if (user == null)
                throw new System.InvalidOperationException("user is null");

            try
            {
                _userData.Add(user);
            }
            catch(Exception ex)
            {
               user.Errors.Add(ex.Message); 
            }
        }

        public void Update(User user)
        {
            if (user == null)
                throw new System.InvalidOperationException("user is null");
            try
            {
                _userData.Update(user);
            }
            catch (Exception ex)
            {
                user.Errors.Add(ex.Message);
            }
        }
    }
}
