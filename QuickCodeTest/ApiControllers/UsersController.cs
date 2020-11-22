using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuickCodeTest.DAL;
using QuickCodeTest.Repository;

namespace QuickCodeTest.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository repo;
        protected readonly ILogger<UsersController> logger;
        public UsersController(IRepository _repo, ILogger<UsersController> _logger = null)
        {
            repo = _repo;
            logger = _logger;
            logger.LogInformation("test");
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<Users>> GetUsers()
        {
            try
            {


                return await repo.GetUsers();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUserById(int id)
        {
            try
            {


                var users = await repo.GetUserById(id);

                if (users == null)
                {
                    return NotFound();
                }

                return users;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users user)
        {
            try
            {


                if (id != user.Id)
                {
                    return BadRequest();
                }

                try
                {
                    await repo.UpdateUser(id, user);
                }
                catch (Exception ex)
                {
                    if (await repo.GetUserById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        logger.LogError(ex.ToString());
                        throw;
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users user)
        {
            try
            {
                var newUser = await repo.CreateUser(user);
                return newUser;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }

        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUsers(int id)
        {
            try
            {


                var user = await repo.DeleteUser(id);
                if (user == null)
                {
                    return NotFound();
                }

                return user;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                throw;
            }
        }


    }
}
