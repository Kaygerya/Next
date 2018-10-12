using MyNextMatch.Core.Entities;
using MyNextMatch.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.Entities.Classes
{
    public class User : BaseEntity, IEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public IEntity GetObject()
        {
            return this;
        }


    }
}
