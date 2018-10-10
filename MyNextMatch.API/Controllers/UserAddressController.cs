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

        [HttpPut]
        [ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.OK)]
        public ActionResult<IEntity> Put(int userId, [FromBody] Address value)
        {
            _userAddressService.UpdateUserAddress(userId, value);
            return Ok(value);
        }

        
    }
}
