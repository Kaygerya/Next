using MyNextMatch.Core.Entities;
using MyNextMatch.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.Entities.Classes
{
    public class UserAddress : BaseEntity, IEntity
    {
        public UserAddress()
            {
            Address = new Address();
            User = new User();
        }

        public User User { get; set; }

        public Address Address { get; set; }

        public IEntity GetObject()
        {
            return this ;
        }
    }
}
