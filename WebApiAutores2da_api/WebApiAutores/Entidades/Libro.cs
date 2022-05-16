using WebApiAutores.Validaciones;
using System.ComponentModel.DataAnnotations;


namespace WebApiAutores.Entidades
{
    public class Libro
    {
        public int Id { get; set; }
         [StringLength(maximumLength:250, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
        [PrimeraMayusculaAttribute]
        public string Titulo { get; set; }
        public int AutorId { get; set; }
         public Autor Autor { get; set; }




    }

}
