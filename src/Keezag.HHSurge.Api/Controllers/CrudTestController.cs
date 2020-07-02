using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Keezag.HHSurge.Application;
using Keezag.HHSurge.Application.Model;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<UserModel>> Get()
        {            
            return _mapper.Map<List<UserModel>>(await  _userApplication.GetAll());
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <param name="profile">professional or personal</param> 
        [HttpPost("{profile}")]
        public async Task<IActionResult> Post(string profile, UserModel user)
        {
            user.Type = profile;
            var newUser = await _userApplication.Add(user);
            return Ok(newUser);
        }

        /// <param name="profile">professional or personal</param> 
        [HttpPost("{id}/{profile}")]
        public void Post(Guid id, string profile, [FromBody] ProfileModel value)
        {
            var i = 1 + 2;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserModel user)
        {
            var i = 1 + 2;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var i = 1 + 2;
        }

        [HttpDelete("{id}/{profile}")]
        public void Delete(int id, string profile)
        {
            var i = 1 + 2;
        }

        /// <param name="profile">professional or personal</param> 
        /// <param name="newprofile">professional or personal</param> 
        [HttpPatch("{id}/{profile}/{newprofile}")]
        public void Delete(int id, string profile, string newprofile)
        {
            var i = 1 + 2;
        }
    }
}
