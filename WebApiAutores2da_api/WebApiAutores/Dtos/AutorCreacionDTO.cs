using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Validaciones;

namespace WebApiAutores.Dtos
{

    public class AutorCreacionDTO
    {

            [Required(ErrorMessage = "El campo {0} es requerido ")]
            [StringLength(maximumLength:120, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
            [PrimeraMayusculaAttribute]
            public string Nombre { get; set; }    
    }
}
