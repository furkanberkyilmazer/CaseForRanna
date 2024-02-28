using AutoMapper;
using CaseForRanna_BackEnd.Bussines.Abstract;
using CaseForRanna_BackEnd.Entities;
using CaseForRanna_BackEnd.Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace CaseForRanna_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;

        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IUserRoleService userRoleService, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _userService = userService;
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Manager")]
        [HttpGet("[action]")]
        public async Task<IActionResult> AllManagers()
        {
            return Ok(await _userService.GetByRoleIdAsync(1));
        }

        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> AllCustomers()
        {
            return Ok(await _userService.GetByRoleIdAsync(2));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveCustomer(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            user.UserRoleId = 2;
            user.UserRole = await _userRoleService.GetByIdAsync(2);
            var userWithUsername = _userService.Where(x => x.Username == userDto.Username).FirstOrDefault();
            if (userWithUsername != null)
                return Ok("Bu kullanıcı adı zaten kullanılıyor.");

            await _userService.AddAsync(user);
            return Ok(_mapper.Map<CreateUserDto>(user));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SaveManager(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            user.UserRoleId = 1;
            user.UserRole = await _userRoleService.GetByIdAsync(1);
            var userWithUsername = _userService.Where(x => x.Username == userDto.Username).FirstOrDefault();
            if (userWithUsername != null)
                return Ok("Bu kullanıcı adı zaten kullanılıyor.");
            await _userService.AddAsync(user);
            return Ok(_mapper.Map<CreateUserDto>(user));
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateManager(UpdateUserDto userDto)
        {
            User user = await _userService.GetByIdAsync(userDto.Id);
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Surname = userDto.Surname;
            user.Username  = userDto.Username;
            

            await _userService.UpdateAsync(user);
            return Ok(_mapper.Map<UpdateUserDto>(user));
        }

        [Authorize]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCustomer(UpdateUserDto userDto)
        {
            User user = await _userService.GetByIdAsync(userDto.Id);
            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Surname = userDto.Surname;
            user.Username = userDto.Username;

            await _userService.UpdateAsync(user);
            return Ok(_mapper.Map<UpdateUserDto>(user));
        }


        [Authorize]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            User user = await _userService.GetByIdAsync(id);
            if (user.UserRoleId == 0)
                return Ok("Bu işlem için yetkiniz yok.");



            await _userService.RemoveAsync(user);
            return Ok("İşlem başarılı.");
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteManager(int id)
        {
            User user = await _userService.GetByIdAsync(id);
            //if (user.UserRoleId == 0)
            //    return Ok("Bu işlem için yetkiniz yok.");



            await _userService.RemoveAsync(user);
            return Ok("İşlem başarılı.");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userService.LoginAsync(loginDto.Username, loginDto.Password);
            if (user == null)
            {
                return Ok("Kullanıcı adı veya şifre hatalı.");

            }

            var claims = new[]
            {
        //new Claim(ClaimTypes.Name,user.Username),
         new Claim(type:"username",user.Username),
      //  new Claim(ClaimTypes.Role,user.UserRole.Name),
      new Claim(type:"role",user.UserRole.Name),
        new Claim(type:"name",user.Name),
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(40),
                signingCredentials: creds);

            return Ok(new
            {
                message="Giriş işlemi başarılı",
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
