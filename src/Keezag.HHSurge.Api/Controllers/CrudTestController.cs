using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Keezag.HHSurge.Application;
using Keezag.HHSurge.Application.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Keezag.HHSurge.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class CrudTestController : ControllerBase
    {
        private readonly IUserApplication _userApplication;

        private readonly IMapper _mapper;

        public CrudTestController(IMapper mapper,
                                  IUserApplication userApplication)
        {           
            _mapper = mapper;
            _userApplication = userApplication;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<List<UserModel>>(await _userApplication.GetAll()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_mapper.Map<UserModel>(await _userApplication.GetById(id)));
        }

        /// <param name="profile">professional or personal</param> 
        [HttpPost("{profile}")]
        public async Task<IActionResult> Post(string profile, UserModel user)
        {
            user.Type = profile;
            var newUser = await _userApplication.Add(user);
            return Ok(newUser);
        }
        
        [HttpPut("{userId}")]
        public async Task<IActionResult> Put(Guid userId, UserModel user)
        {
            user.UserId = userId;
            var newUser = await _userApplication.Update(user);
            return Ok(newUser);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            return Ok(await _userApplication.Delete(userId));
        }

        /// <param name="profile">professional or personal</param> 
        /// <param name="newprofile">professional or personal</param> 
        [HttpPatch("{userId}/{profile}/{newprofile}")]
        public async Task<IActionResult> ChangeProfileType(Guid userId, string profile, string newprofile)
        {
            return Ok(await _userApplication.ChangeProfileType(userId, profile, newprofile));
        }
    }
}
