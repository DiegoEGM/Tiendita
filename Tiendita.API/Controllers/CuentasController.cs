using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tiendita.API.Data;
using Tiendita.API.Models;

namespace Tiendita.API.Controllers
{
  //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public CuentasController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("registro")]
        public async Task<ActionResult<UserToken>> RegistroUsuario([FromBody] User user)
        {
            var usuario = new IdentityUser
            { UserName = user.Username };

            var result = await userManager.CreateAsync(usuario, user.Password);

            if (result.Succeeded)
            {
                return BuildToken(user);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] User model)
        {
            var result = await signInManager.PasswordSignInAsync(
                model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return BuildToken(model);
            }
            else
            {
                return BadRequest("Login fallido");
            }
        }
        private UserToken BuildToken(User user)
        {

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["jwtkey"]));

            var credential = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1700);

            JwtSecurityToken token = new JwtSecurityToken(
                               issuer: null,
                               audience: null,
                               claims : claims,
                               expires: expiration,
                               signingCredentials: credential);

            return new UserToken
            {
                Token = new JwtSecurityTokenHandler()
                .WriteToken(token),
                Expiration = expiration
            };
        }

        [HttpPost("actualizar")]
        public async Task<ActionResult<UserToken>> Actualizar([FromBody] User user)
        {
            var usuario = await userManager.FindByNameAsync(user.Username);
            if (usuario == null) {
                return NotFound("El usuario no existe");
            }
            var respuesta1 = await userManager.RemovePasswordAsync(usuario);
            if (!respuesta1.Succeeded) {
                return BadRequest("No se pudo borrar la contraseña");
            }
            var respuesta2 = await userManager.AddPasswordAsync(usuario, user.Password);
            if(!respuesta2.Succeeded) {
                return BadRequest("No se ha podido actualizar la contraseña");
            }
            else {
                return Ok("Se ha actualizado la contraseña");
            }
        }
    }
}
