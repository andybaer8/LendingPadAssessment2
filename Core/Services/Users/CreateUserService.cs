using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Users
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IUpdateProductService _updateUserService;
        private readonly IIdObjectFactory<User> _userFactory;
        private readonly IUserRepository _userRepository;

        public CreateProductService(IIdObjectFactory<User> userFactory, IUserRepository userRepository, IUpdateProductService updateUserService)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _updateUserService = updateUserService;
        }

        public User Create(Guid id, string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            var user = _userFactory.Create(id);
            _updateUserService.Update(user, name, email, type, annualSalary, tags);
            _userRepository.Save(user);
            return user;
        }
    }
}