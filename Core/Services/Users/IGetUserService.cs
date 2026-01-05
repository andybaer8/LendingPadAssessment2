using BusinessEntities;
using Raven.Abstractions.Data;
using System;
using System.Collections.Generic;

namespace Core.Services.Users
{
    public interface IGetProductService
    {
        User GetUser(Guid id);
        IEnumerable<User> GetUsersByTag(string tag);
        IEnumerable<User> GetUsers(UserTypes? userType = null, string name = null, string email = null);
    }
}