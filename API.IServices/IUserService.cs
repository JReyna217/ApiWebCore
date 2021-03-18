using API.Entities;
using System.Collections.Generic;

namespace API.IServices
{
    public interface IUserService
    {
        string LastError { get; }

        List<User> GetUsers();
    }
}
