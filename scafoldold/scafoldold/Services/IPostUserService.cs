using Microsoft.AspNetCore.Mvc;
using scafoldold.Controllers;

namespace scafoldold.Services
{
    public interface IPostUserService
    {
        Task<IActionResult> CreateUserAsync(UsersController.UserCreateDto dto);
    }
}
