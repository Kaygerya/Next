using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNextMatch.Core.Entities;
using MyNextMatch.Entities.Classes;
using MyNextMatch.Service.Abstract;

namespace MyNextMatch.UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), (int)HttpStatusCode.OK)]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEntity), (int)HttpStatusCode.OK)]
        public ActionResult<IEntity> Post([FromBody] User value)
        {
            _userService.Insert(value);
            return Ok(value);
        }

    }
}
