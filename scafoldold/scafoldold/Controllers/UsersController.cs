using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scafoldold.Models;
using scafoldold.Services;



namespace scafoldold.Controllers
{



   

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatasContext _context;
        private readonly AppDbContext _appContext;
        private readonly IDeleteservice _deleteService;
        private readonly IPostUserService _postUserService;
        private readonly Ipatchservice _patchUserService;


        public UsersController(DatasContext context, AppDbContext appContext, IDeleteservice deleteservice, IPostUserService postUserService, Ipatchservice patchUserService)
        {
            _context = context;
            _appContext = appContext;
            _deleteService = deleteservice;
            _postUserService = postUserService;
            _patchUserService = patchUserService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return await _deleteService.DeleteUserAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] UserCreateDto dto)
        {
            return await _postUserService.CreateUserAsync(dto);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUser(int id, [FromBody] UserEditDto dto)
        {
            return await _patchUserService.PatchUserAsync(id, dto);  
        }



        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //        return NotFound();

        //    user.IsDeleted = true;
        //    await _context.SaveChangesAsync();

        //    return Ok(new { message = "Deleted" });
        //}



        //[HttpGet("edit/{id}")]
        //public async Task<ActionResult<UserEditDto>> GetUserForEdit(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null) return NotFound();

        //    var dto = new UserEditDto
        //    {
        //        Id = user.Id,
        //        Name = user.Name,
        //        Lastname = user.Lastname,
        //        Email = user.Email,
        //        Phone = user.Phone,
        //        Dob = user.Dob
        //    };

        //    return Ok(dto);
        //}



        //[HttpPatch("{id}")]
        //public async Task<IActionResult> Patchunits(int id, [FromBody] UserEditDto dto)
        //{
        //    var user = await _context.Users.FindAsync(id);

        //    if (user == null)
        //        return NotFound(new { message = "User not found" });

        //    if (dto.Name != null)
        //        user.Name = dto.Name;

        //    if (dto.Lastname != null)
        //        user.Lastname = dto.Lastname;

        //    if (dto.Email != null)
        //        user.Email = dto.Email;

        //    if (dto.Phone != null)
        //        user.Phone = dto.Phone;

        //    if (dto.Dob.HasValue)
        //        user.Dob = dto.Dob;

        //    if (dto.Units.HasValue)
        //        user.Units = dto.Units.Value;

        //    await _context.SaveChangesAsync();


        //    return Ok(new
        //    {
        //        message = "User updated successfully",
        //        user.Id,
        //        user.Name,
        //        user.Lastname,
        //        user.Email,
        //        user.Phone,
        //        user.Dob,
        //        user.Units
        //    });
        //}




        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserWithLocationDto>>> GetUsers()
        {
            var users = await _context.Users
                         .Where(u => u.IsDeleted == false)
                         .ToListAsync();


            var locations =
                from p in _appContext.ProjIds
                join c in _appContext.ProjCountries on p.CountryId equals c.CountryId into cj
                from c in cj.DefaultIfEmpty()
                join s in _appContext.ProjStates on p.StateId equals s.StateId into sj
                from s in sj.DefaultIfEmpty()
                join d in _appContext.ProjDistricts on p.DistrictId equals d.DistrictId into dj
                from d in dj.DefaultIfEmpty()
                select new
                {
                    p.UsersId,
                    p.CountryId,
                    CountryName = c.CountryNames,
                    p.StateId,
                    StateName = s.StateNames,
                    p.DistrictId,
                    DistrictName = d.DistrictNames
                };

            var locationList = await locations.ToListAsync();

            var result =
                from u in users
                join l in locationList on u.Id equals l.UsersId into lj
                from l in lj.DefaultIfEmpty()
                select new UserWithLocationDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Lastname = u.Lastname,
                    Email = u.Email,
                    Phone = u.Phone,
                    Dob = u.Dob,
                    Submitted = u.Submitted,
                    Skills = u.Skills,
                    Units = u.Units,
                    CountryId = l?.CountryId,
                    CountryName = l?.CountryName,
                    StateId = l?.StateId,
                    StateName = l?.StateName,
                    DistrictId = l?.DistrictId,
                    DistrictName = l?.DistrictName
                };

            return Ok(result);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }

        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser([FromBody] UserCreateDto dto)
        //{
        //    try
        //    {
        //        var user = new User
        //        {
        //            Name = dto.Name,
        //            Lastname = dto.Lastname,
        //            Email = dto.Email,
        //            Phone = dto.Phone,
        //            Dob = dto.Dob,
        //            Skills = dto.Skills,
        //            Units = dto.Units,
        //            Submitted = dto.Submitted
        //        };

        //        _context.Users.Add(user);
        //        await _context.SaveChangesAsync();


        //        var projId = new ProjId
        //        {
        //            UsersId = user.Id,
        //            CountryId = dto.CountryId,
        //            StateId = dto.StateId,
        //            DistrictId = dto.DistrictId
        //        };

        //        _appContext.ProjIds.Add(projId);
        //        await _appContext.SaveChangesAsync();

        //        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        return BadRequest(new
        //        {
        //            message = "Database update failed",
        //            error = ex.Message,
        //            innerError = ex.InnerException?.Message
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new
        //        {
        //            message = "Unexpected error",
        //            error = ex.Message
        //        });
        //    }
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UserCreateDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest(new { message = "User ID in URL and body do not match" });
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            user.Name = dto.name;
            user.Lastname = dto.lastname;
            user.Email = dto.email;
            user.Phone = dto.phone;
            user.Dob = dto.dob;
            user.Skills = dto.skills;
            user.Units = dto.Units;
            //user.Submitted = dto.Submitted;

            var projId = await _appContext.ProjIds.FirstOrDefaultAsync(p => p.UsersId == id);
            if (projId != null)
            {
                projId.CountryId = dto.countryid ?? projId.CountryId;
                projId.StateId = dto.stateid ?? projId.StateId;
                projId.DistrictId = dto.districtid ?? projId.DistrictId;
            }
            else
            {
                var newProjId = new ProjId
                {
                    UsersId = id,
                    CountryId = dto.countryid,
                    StateId = dto.stateid,
                    DistrictId = dto.districtid
                };
                _appContext.ProjIds.Add(newProjId);
            }

            try
            {
                await _context.SaveChangesAsync();
                await _appContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new
                {
                    message = "Database update failed",
                    error = ex.Message,
                    innerError = ex.InnerException?.Message
                });
            }

            return Ok(new
            {
                message = "User updated successfully",
                user.Id,
                user.Name,
                user.Lastname,
                user.Email,
                user.Phone,
                user.Dob,
                //user.Units
            });
        }


        [HttpGet("proj_country")]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var data = await _appContext.ProjCountries.ToListAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }


        [HttpGet("proj_state")]
        public async Task<ActionResult<IEnumerable<ProjState>>> GetStates([FromQuery] int countryId)
        {
            var states = await _appContext.ProjStates
                                       .Where(s => s.CountryId == countryId)
                                       .ToListAsync();
            return states;
        }


        [HttpGet("proj_district")]
        public async Task<ActionResult<IEnumerable<ProjDistrict>>> GetDistricts([FromQuery] int stateId)
        {
            var districts = await _appContext.ProjDistricts
                                             .Where(d => d.StateId == stateId)
                                             .ToListAsync();
            return Ok(districts);
        }


        public class UserCreateDto
        {
            public int Id { get; set; }
            public string? name { get; set; }
            public string? lastname { get; set; }
            public string? email { get; set; }
            public string? phone { get; set; }
            public DateOnly? dob { get; set; }
            public string? skills { get; set; }
            public int? Units { get; set; }

            public string? Submitted { get; set; }


            public int? countryid { get; set; }
            public int? stateid { get; set; }
            public int? districtid { get; set; }
        }

        public class UserEditDto
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Lastname { get; set; }
            public string? Email { get; set; }
            public string? Phone { get; set; }
            public DateOnly? Dob { get; set; }
            public int? Units { get; set; }
        }




    }
}
