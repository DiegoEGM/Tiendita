using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tiendita.API.Data;
using Tiendita.API.Models;


namespace Tiendita.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]

    public class BotanasController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public BotanasController(ApplicationDbContext context)
        {   
            this.context = context;
        }

        [AllowAnonymous]
        [HttpPost("registro")]
        public async Task<ActionResult<int>> Guardar(Botana botana)
        {
            var nueva_botana = botana;
            context.Add(nueva_botana);
            await context.SaveChangesAsync();
            if (nueva_botana.Id <= 0)
            {
                return BadRequest();
            }
            else
            {
                return nueva_botana.Id;
            }
        }
        [AllowAnonymous]
        [HttpGet("lista")]
        public async Task<ActionResult<List<Botana>>> Registros()
        {
            var lista = new List<Botana>();
            lista = await context.Botanas.ToListAsync();
            if (lista.Count > 0)
            {
                return lista;
            }
            else
            {
                return NoContent();
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteBotana(int id)
        {
            var compra = await context.Botanas.FindAsync(id);
            if (compra == null)
                return NotFound();
            context.Botanas.Remove(compra);
            await context.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("botana/{id}")]
        public async Task<ActionResult<Botana>> GetBotana(int id)
        {
            var botana = await context.Botanas.FirstOrDefaultAsync(x => x.Id == id);
            if (botana == null)
            {
                return NotFound();
            }
            return botana;
        }
    }
}
