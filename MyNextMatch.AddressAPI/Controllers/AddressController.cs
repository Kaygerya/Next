using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNextMatch.Core.Entities;
using MyNextMatch.Entities.Classes;
using MyNextMatch.Service.Abstract;

namespace MyNextMatch.AddressAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get()
        {
            return _addressService.GetAll();
        }


        // POST api/values
        [HttpPost("{userId}")]
        public ActionResult<IEntity> Post(int userId, [FromBody] Address value)
        {
            value.Owner = userId;
            _addressService.Insert(value);
            return value;
        }

        [HttpPut("{userId}")]
        public ActionResult<IEntity> Put(int userId, [FromBody] Address value)
        {
            //insert
            if(value.AddressId == 0)
            {
                value.Owner = userId;
                _addressService.Insert(value);
            }
            //update
            else if(value.Owner == userId && value.Id > 0)
                _addressService.Update(value);

            return value;
        }
    }
}
