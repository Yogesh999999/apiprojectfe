using Microsoft.AspNetCore.Mvc;
using scafoldold.Models;

namespace scafoldold.Services
{
    public class UserDeleteService : IDeleteservice
    {
        private readonly DatasContext _context;

        public UserDeleteService(DatasContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return new NotFoundObjectResult(new { message = "User not found" });

            user.IsDeleted = true;   
            await _context.SaveChangesAsync();

            return new OkObjectResult(new { message = "User deleted successfully" });
        }
    }
}
