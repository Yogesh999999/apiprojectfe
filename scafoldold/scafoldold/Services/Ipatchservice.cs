using Microsoft.AspNetCore.Mvc;
using static scafoldold.Controllers.UsersController;

namespace scafoldold.Services
{
    public interface Ipatchservice
    {
        Task<IActionResult> PatchUserAsync(int id, UserEditDto dto);

    }
}
