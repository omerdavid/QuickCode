using QuickCodeTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCodeTest.Repository
{
   public interface IRepository
    {
        Task<IEnumerable<Users>> GetUsers();
        Task<Users> GetUserById(int id);

        Task UpdateUser(int id, Users user);

        Task<Users> CreateUser(Users user);

        Task<Users> DeleteUser(int id);
    }
}
