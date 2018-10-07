using MyNextMatch.Core.DataAccess.EntityFramework;
using MyNextMatch.DataAccess.Abstract;
using MyNextMatch.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.DataAccess.Services
{
    public class EfUserDAL: EfEntityRepositoryBase <User,MyNextMatchDatabaseContext >, IUserDAL
    {
    }
}
