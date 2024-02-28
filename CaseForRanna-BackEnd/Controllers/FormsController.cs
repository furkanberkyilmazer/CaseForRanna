using AutoMapper;
using CaseForRanna_BackEnd.Bussines.Abstract;
using CaseForRanna_BackEnd.Bussines.Concrete;
using CaseForRanna_BackEnd.Entities.Dtos;
using CaseForRanna_BackEnd.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CaseForRanna_BackEnd.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly IFormService _formService;

        private readonly IUserService _userService;

        private readonly IMapper _mapper;

        public FormsController(IFormService formService, IMapper mapper, IUserService userService)
        {
            _formService = formService;
            _mapper = mapper;
            _userService = userService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> AllForms()
        {
            return Ok(await _formService.GetAllAsync());
        }
    
        [HttpPost("[action]")]
        public async Task<IActionResult> SaveForm(CreateFormDto formDto)
        {
            Form form = _mapper.Map<Form>(formDto);
            var user = await _userService.GetByUserNameAsync(formDto.Username);
            form.User = user;
            form.UserId=user.Id;
            await _formService.AddAsync(form);
            return Ok(_mapper.Map<CreateFormDto>(form));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateForm(UpdateUserDto formDto)
        {
            Form form =await _formService.GetByIdAsync(formDto.Id);
             form = _mapper.Map<Form>(formDto);
            await _formService.UpdateAsync(form);
            return Ok(_mapper.Map<UpdateUserDto>(form));
        }
      

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteForm(int id)
        {
            Form form = await _formService.GetByIdAsync(id);
            //if (user.UserRoleId == 0)
            //    return Ok("Bu işlem için yetkiniz yok.");



             await _formService.RemoveAsync(form);
            return Ok("İşlem başarılı.");
        }
        [HttpGet("[action]")]
        public  async Task<IActionResult> GetByUsernameForms(string username)
        {
            return Ok(await _formService.GetByUserNameAsync(username));
        }

    }
}
