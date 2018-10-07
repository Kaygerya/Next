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
            _userAddressService.Insert(user);
            return View(user);
        }

        public ActionResult GetAllUsers()
        {
            var users =_userAddressService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public ActionResult UserAddress(int userId)
        {
            Address address = new Address();
            address.Owner = userId;
            if (TempData["Address"] != null)
            {
                address= (Address)TempData["Address"];
            }
            return View(address);
        }

        [HttpPost]
        public ActionResult UserAddress(int userId, Address address)
        {
            _userAddressService.UpdateUserAddress(userId, address);
            TempData["Address"] = address;
            return UserAddress(userId);
        }

        
    }
}