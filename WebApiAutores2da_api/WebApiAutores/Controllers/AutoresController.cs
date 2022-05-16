using System.IO.MemoryMappedFiles;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;
using AutoMapper;
using WebApiAutores.Dtos;

namespace WebApiAutores.Controllers
{
    [ApiController]
    // se puede usar en la ruta   api/[controller] 
    [Route("api/autores")]

    public class AutoresController : ControllerBase
    {

        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public AutoresController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

          // api/autores
        // [HttpGet("listado")] // api/autores/listado
        // [HttpGet("/listado")] //listado  (ruta absoluta)
         [HttpGet]
        public async Task<ActionResult<List<AutorDTO>>> Get()
        {
            var autores =  await context.Autores.Include(x=> x.Libros).ToListAsync();
            return mapper.Map<List<AutorDTO>>(autores);
        }

    // le tengo que agregar a la ruta para q no haya ambiguedad con el anterior metodo get
        
        // buscar por id
        [HttpGet("{id:int}")] // api/autores/id
        public async Task<ActionResult<AutorDTO>> Get(int id)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
            if(autor == null)
            {
                return NotFound();
            }

            return mapper.Map<AutorDTO>(autor);

        }
        // Dos parametros
        // [HttpGet("{id:int}/{parametro2?}")] // poniendo ? digo q es opcional, acepto valor nulo a ese param // o ponerle valor por defecto. seria {parametro2 = valor}                                     
        // public async Task<ActionResult<Autor>> Get(int id,string parametro2)
        // {
        //     var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);
        //     if(autor == null)
        //     {
        //         return NotFound();
        //     }

        //     return autor;

        // }


        // // buscar por nombre
        //  [HttpGet("{nombre}")] // api/autores/nombre
        // public async Task<ActionResult<Autor>> Get([FromRoute] string nombre)
        // {
        //     var autor = await context.Autores.FirstOrDefaultAsync(x => x.Nombre.Contains(nombre));
        //     if(autor == null)
        //     {
        //         return NotFound();
        //     }

        //     return autor;

        // }

        // MODEL BINDING 
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AutorCreacionDTO autorCreacionDTO)
        {

            // validacion a nivel del controlador
            var existeAutorMismoNombre= await context.Autores.AnyAsync(x => x.Nombre == autorCreacionDTO.Nombre);

            if(existeAutorMismoNombre)
            {
                return BadRequest($"Ya existe un autor con el nombre {autorCreacionDTO.Nombre}");
            }
            
            var autor = mapper.Map<Autor>(autorCreacionDTO);

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


        // TIPOS DE DATOS QUE SE PUEDEN USAR

        // ESPECIFICO POR EJEMPLO EN EL GET SOLO USAR POR EJEMPLO : List<Autor>
        /* public <List<Autor> Get()
            {
                 return context.Autores.Include(x=> x.Libros).ToList();
            }
        */

        // El Action result es el q devuelve los status y se puede usar por ejemplo
        // ActionResult<Autor>  en este caso si usamos eso quiere decir q podemos retornar
        // o un action result o un autor

        // IActionResult no se puede controlar el tipo de dato devuelto 
        // ejemplo se puede retornar  return Ok(autor), return Ok(3), return Ok("hola")

        // programacion asincrona es mas eficiente. pero solo se utiliza cuando es necesario
        // generalmente cuando consultamos otras apis o base de datos


    }
}






