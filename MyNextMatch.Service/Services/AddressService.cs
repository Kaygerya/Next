using MyNextMatch.DataAccess.Abstract;
using MyNextMatch.Entities.Base;
using MyNextMatch.Entities.Classes;
using MyNextMatch.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.Service.Services
{
    public class AddressService : IAddressService
    {
        private IAddressDAL _addressData { get; set; }

        public AddressService(IAddressDAL addressDAL)
        {
            this._addressData = addressDAL;
        }

        public List<Address> GetAll()
        {
            return _addressData.GetList();
        }

        public Address GetById(int addressId)
        {
            if(addressId == 0)
                throw new System.InvalidOperationException("addressId 0");

            return _addressData.Get(u => u.AddressId == addressId);
        }

        public void Insert(Address address)
        {
            if (address == null)
                throw new System.InvalidOperationException("address is null");

            try
            {
                _addressData.Add(address);
            }
            catch (Exception ex)
            {
                address.Errors.Add(ex.Message);
            }
        }

        public void Update(Address address)
        {
            if (address == null)
                throw new System.InvalidOperationException("address is null");

            try
            {
                _addressData.Update(address);
            }
            catch (Exception ex)
            {
                address.Errors.Add(ex.Message);
            }
        }

        public void Delete(int addressId)
        {
            if (addressId == 0)
                throw new System.InvalidOperationException("addressId is 0");

            var address = GetById(addressId);
            if (address == null)
                throw new System.InvalidOperationException("address is null");

            try
            {
                _addressData.Delete(address);
            }
            catch (Exception ex)
            {
                address.Errors.Add(ex.Message);
            }
        }
    }
}
