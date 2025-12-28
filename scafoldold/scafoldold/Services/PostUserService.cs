using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scafoldold.Models;
using scafoldold.Controllers;

namespace scafoldold.Services
{
    public class PostUserService : IPostUserService
    {
        private readonly DatasContext _context;
        private readonly AppDbContext _appContext;

        public PostUserService(DatasContext context, AppDbContext appContext)
        {
            _context = context;
            _appContext = appContext;
        }

        public async Task<IActionResult> CreateUserAsync(UsersController.UserCreateDto dto)
        {
            try
            {
                var user = new User
                {
                    Name = dto.name,
                    Lastname = dto.lastname,
                    Email = dto.email,
                    Phone = dto.phone,
                    Dob = dto.dob,
                    Skills = dto.skills,
                    Units = dto.Units,
                    Submitted = dto.Submitted
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                var projId = new ProjId
                {
                    UsersId = user.Id,
                    CountryId = dto.countryid,
                    StateId = dto.stateid,
                    DistrictId = dto.districtid
                };

                _appContext.ProjIds.Add(projId);
                await _appContext.SaveChangesAsync();

                return new CreatedAtActionResult(
                    "GetUser",
                    "Users",
                    new { id = user.Id },
                    user
                );
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
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    message = "Unexpected error",
                    error = ex.Message
                });
            }
        }
    }
}
