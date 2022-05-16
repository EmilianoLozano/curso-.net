using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]

    public class AutoresController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.Include(x=> x.Libros).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]   // api/autores/id
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("El id del autor no coincide");// error 400
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var existe = await context.Autores.AnyAsync(x => x.Id == id); // verifica si existe el id pasado por parametro
            // si no existe es falso y preguntamos
            if (!existe)
            {
                return NotFound();
            }

            context.Remove(new Autor() { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}






