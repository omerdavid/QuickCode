using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuickCodeTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickCodeTest.Repository
{
    public class UsersRepository : IRepository
    {
        private UsersDbContext context;
        protected readonly ILogger<UsersRepository> logger;
        public UsersRepository(UsersDbContext _context,  ILogger<UsersRepository> _logger)
        {
            context = _context;
            logger = _logger;
        }
        public async Task<Users> CreateUser(Users user)
        {
            try
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();

                logger.LogInformation(string.Format("{0}:{1} {2},Id :{3}","New user was added ",user.FirstName,user.LastName,user.Id));
               
                return user;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<Users> DeleteUser(int id)
        {
            try
            {
                var user = await context.Users.FindAsync(id);
                if (user == null)
                    return null;
                context.Users.Remove(user);

                await context.SaveChangesAsync();
                logger.LogInformation(string.Format("{0}:{1},Id :{2}", "User was deleted ", user.FirstName + user.LastName, user.Id));
                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Find user entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User if no entity found returns null</returns>
        public async Task<Users> GetUserById(int id)
        {
            try
            { 
               
              return await  context.FindAsync<Users>(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Users>> GetUsers()
        {
            try
            {
                return await context.Users.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateUser(int id, Users user)
        {
            try
            {
                context.Entry(user).State = EntityState.Modified;
                await context.SaveChangesAsync();
                logger.LogInformation(string.Format("{0}:{1},Id :{2}", "User details was updated ", user.FirstName + user.LastName, user.Id));
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
