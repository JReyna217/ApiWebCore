using API.Entities;
using API.IRepository;
using API.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public List<User> GetUsers()
        {
            List<User> users = _repository.Table.Where(c => c.Deleted == false).ToList();

            return users;
        }
    }
}
