using AutoMapper;
using WebApiAutores.Dtos;
using WebApiAutores.Entidades;

namespace WebApiAutores.Utilidades
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<AutorCreacionDTO, Autor>();
            CreateMap<Autor,AutorDTO>();

            CreateMap<LibroCreacionDTO,Libro>();

             CreateMap<Libro,LibroDTO>();
        }
    }
}
