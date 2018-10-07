using MyNextMatch.Core.Entities;
using MyNextMatch.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.Entities.Classes
{
    public class Address : BaseEntity, IEntity
    {
        public int AddressId { get; set; }
        public string PostCode { get; set; }
        public string AddressLine { get; set; }
        public int Owner { get; set; }
        public string OwnerType { get; set; }


        IEntity IEntity.GetObject()
        {
            return new Address();
        }
    }
}
