using Microsoft.AspNetCore.Mvc;

namespace scafoldold.Services
{
    public interface IDeleteservice
    {
        Task<IActionResult> DeleteUserAsync(int id);
    }
}
