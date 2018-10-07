using MyNextMatch.Entities.Base;
using MyNextMatch.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.Service.Abstract
{
    public interface IAddressService
    {
        List<Address> GetAll();
        Address GetById(int addressId);
        void Insert(Address address);
        void Update(Address address);
        void Delete(int addressId);
    }
}
