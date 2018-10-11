using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNextMatch.Entities.Classes;
using MyNextMatch.Service.Abstract;

namespace MyNextMatch.WEBTEST.Controllers
{
    public class DefaultController : Controller
    {
        IUserAddressService _userAddressService;
        public DefaultController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InsertUser()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult InsertUser(User user)
        {
            _userAddressService.InsertUser(user);
            return View(user);
        }

        public ActionResult GetAllUsers()
        {
            var users =_userAddressService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult UserAddress()
        {
            UserAddress userAddress = new UserAddress();

            if (TempData["UserAddress"] != null)
            {
                userAddress = (UserAddress)TempData["userAddress"];
            }
 
            return View(userAddress);
        }

        [HttpPut]
        public ActionResult UserAddress(int userId, UserAddress useraddress )
        {
            var userResult = _userAddressService.InsertUser(useraddress.User);
            if(userResult.IsSuccess)
            {
                useraddress.Address.Owner = userResult.UserId;
                Address addressResult = new Address();
                if(useraddress.Address.AddressId > 0)
                {
                    addressResult = _userAddressService.UpdateAddress(useraddress.Address);
                }
                else
                {
                    addressResult = _userAddressService.InsertAddress(useraddress.Address);
                }
               
                if(addressResult.IsSuccess)
                {
                    useraddress.User = userResult;
                    useraddress.Address = addressResult;
                    return View(useraddress);
                }
                else
                {
                    var deleteResponse  =_userAddressService.DeleteUser(userResult.UserId);
                    return View(useraddress);
                }
            }
            else
            {
                return View(useraddress);
            }
        }

        [HttpPost]
        public ActionResult UserAddress( UserAddress useraddress)
        {
            return UserAddress(useraddress.Id, useraddress);
        }

    }
}