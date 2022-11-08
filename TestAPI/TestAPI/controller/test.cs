using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TestAPI.ModelClass;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Data;

namespace TestAPI.controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class test
    {
        private readonly ServiceLogin serviceLogin;
        public test(ServiceLogin serviceLogin)
        {
            this.serviceLogin = serviceLogin;
        }
        [HttpGet]
        [Route("test")]
        public async Task<List<Users>> Get()
        {
            return await serviceLogin.Get();
        }
    }
}
