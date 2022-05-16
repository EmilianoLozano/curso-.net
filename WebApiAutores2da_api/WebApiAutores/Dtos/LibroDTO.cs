

using WebApiAutores.Entidades;

namespace WebApiAutores.Dtos
{
public class LibroDTO
{
       public int Id { get; set; }
  
       public string Titulo { get; set; } 
       public Autor Autor { get; set; }

}
}