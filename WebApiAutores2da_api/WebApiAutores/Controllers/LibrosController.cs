using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO.Compression;
using System.Diagnostics.Contracts;
using System.ComponentModel.Design.Serialization;
using System.Threading;
using System;
using System.Globalization;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApiAutores.Entidades;
using Microsoft.EntityFrameworkCore;    
using WebApiAutores.Dtos;



namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]

    public class LibrosController : ControllerBase

    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LibrosController(ApplicationDbContext context,IMapper mapper)

        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LibroDTO>> Get(int id)
        {

            var libro = await context.Libros.Include(x=>x.Autor).FirstOrDefaultAsync(x => x.Id == id);
            return mapper.Map<LibroDTO>(libro); 

        }

        [HttpPost]
        public async Task<ActionResult> Post(LibroCreacionDTO libroCreacionDTO)
        {
            // var existeAutor = await context.Autores.AnyAsync(x => x.Id == libro.AutorId);

            // if (!existeAutor)
            // {
            //     return BadRequest($"No existe el autor de Id : {libro.AutorId}");
            // }

            var libro = mapper.Map<Libro>(libroCreacionDTO);

            context.Add(libro);
            await context.SaveChangesAsync();
            return Ok();
        }




    }

}
