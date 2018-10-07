using MyNextMatch.Core.DataAccess;
using MyNextMatch.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.DataAccess.Abstract
{
    public interface IAddressDAL : IEntityRepository<Address>
    {
    }
}
