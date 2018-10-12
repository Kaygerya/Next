using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNextMatch.Core.Entities;
using MyNextMatch.Entities.Classes;
using MyNextMatch.Service.Abstract;

namespace MyNextMatch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAddressController : ControllerBase
    {
        private IUserAddressService _userAddressService;
        public UserAddressController(IUserAddressService userAddressService)
        {
            _userAddressService = userAddressService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userAddressService.GetAllUsers());
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.OK)]
        public ActionResult<IEntity> Post([FromBody] User value)
        {
            _userAddressService.InsertUser(value);
            return Ok(value);
        }

        [HttpPut]
        [ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.OK)]
        public ActionResult<UserAddress> Put(int userId, [FromBody] UserAddress value)
        {
            var userResult = _userAddressService.InsertUser( value.User);
            if(userResult.IsSuccess)
            {
                value.Address.Owner = userResult.UserId;
                var addressResult =_userAddressService.InsertAddress(value.Address);
                if(addressResult.IsSuccess)
                {
                    value.User = userResult;
                    value.Address = addressResult;
                    return Ok(value);
                }
                else
                {
                    var deleteResponse  =_userAddressService.DeleteUser(userResult.UserId);
                    return NotFound(deleteResponse);
                }
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}
