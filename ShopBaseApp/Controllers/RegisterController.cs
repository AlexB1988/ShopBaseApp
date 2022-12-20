using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ShopBaseApp.Domain;
using ShopBaseApp.Domain.Entities;

namespace ShopBaseApp.Controllers
{
    [ApiController]
    [Route("api/register")]
    public class RegisterController:Controller
    {
        public DataContext _dataContext;
        public RegisterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task <IActionResult> Register(string userName, string email, string password)
        {
            if(userName!=null && email!=null && password != null)
            {
                var tempUser =_dataContext.Users.FirstOrDefault(u => u.UserName == userName || u.Email == email);
                if (tempUser is null)
                {
                    PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                    var user = new User();
                    user = new User
                    {
                        UserName = userName,
                        Email = email,
                        Password = passwordHasher.HashPassword(user, password),
                        RoleId = 2
                    };

                    await _dataContext.Users.AddAsync(user);
                    await _dataContext.SaveChangesAsync();
                    return Ok();
                }


            }
            throw new Exception("The user is alredy exists");
           
        }
    }
}
