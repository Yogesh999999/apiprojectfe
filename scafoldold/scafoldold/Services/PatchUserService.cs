using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using scafoldold.Models;
using scafoldold.Services;
using static scafoldold.Controllers.UsersController;

public class PatchUserService : Ipatchservice
{
    private readonly DatasContext _context;

    public PatchUserService(DatasContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> PatchUserAsync(int id, UserEditDto dto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            return new NotFoundResult();

        if (dto.Name != null) user.Name = dto.Name;
        if (dto.Lastname != null) user.Lastname = dto.Lastname;
        if (dto.Email != null) user.Email = dto.Email;
        if (dto.Phone != null) user.Phone = dto.Phone;
        if (dto.Dob.HasValue) user.Dob = dto.Dob.Value;
        if (dto.Units.HasValue) user.Units = dto.Units.Value;

        try
        {
            await _context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                message = "User updated successfully",
                user.Id,
                user.Name,
                user.Lastname,
                user.Email,
                user.Phone,
                user.Dob,
                user.Units
            });
        }
        catch (DbUpdateException ex)
        {
            return new BadRequestObjectResult(new
            {
                message = "Database update failed",
                error = ex.Message,
                innerError = ex.InnerException?.Message
            });
        }
    }
}
