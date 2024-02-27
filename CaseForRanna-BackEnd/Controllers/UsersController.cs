using AutoMapper;
using CaseForRanna_BackEnd.Bussines.Abstract;
using CaseForRanna_BackEnd.Entities;
using CaseForRanna_BackEnd.Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseForRanna_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;

        private readonly IMapper _mapper;
        public UsersController(IUserService userService, IUserRoleService userRoleService, IMapper mapper)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> AllManagers()
        {
            return Ok(await _userService.GetByRoleIdAsync(0));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> AllCustomers()
        {
            return Ok(await _userService.GetByRoleIdAsync(1));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SaveCustomers(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            user.UserRoleId = 1;
            user.UserRole =await _userRoleService.GetByIdAsync(1);
            _userService.AddAsync(user);
            return Ok(_mapper.Map<CreateUserDto>(user));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SaveManager(CreateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            user.UserRoleId = 0;
            user.UserRole = await _userRoleService.GetByIdAsync(0);
            _userService.AddAsync(user);
            return Ok(_mapper.Map<CreateUserDto>(user));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateManager(UpdateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            user.UserRoleId = 0;
            user.UserRole = await _userRoleService.GetByIdAsync(0);
            _userService.UpdateAsync(user);
            return Ok(_mapper.Map<UpdateUserDto>(user));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateCustomets(UpdateUserDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            user.UserRoleId = 1;
            user.UserRole = await _userRoleService.GetByIdAsync(1);
            _userService.UpdateAsync(user);
            return Ok(_mapper.Map<UpdateUserDto>(user));
        }
    }
}
