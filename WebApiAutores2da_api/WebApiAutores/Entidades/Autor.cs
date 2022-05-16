using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Validaciones;

namespace WebApiAutores.Entidades
{

    public class Autor 
    {
  
        public int Id { get; set; }

        // utiliza placeholders con {} para sustituir los nombres d la variable o validacion
        [Required(ErrorMessage = "El campo {0} es requerido ")]
        [StringLength(maximumLength:120, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
        [PrimeraMayusculaAttribute]
        public string Nombre { get; set; }
        public List<Libro> Libros { get; set; }








    }

}