using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNextMatch.Core.Entities;
using MyNextMatch.Entities.Classes;
using MyNextMatch.Service.Abstract;

namespace MyNextMatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserAddressService _userAddressService;
        public UserController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _userAddressService.GetAllUsers();
        }

        [HttpPost]
        public ActionResult<IEntity> Post([FromBody] User value)
        {
            _userAddressService.Insert(value);
            return value;
        }
    }
}