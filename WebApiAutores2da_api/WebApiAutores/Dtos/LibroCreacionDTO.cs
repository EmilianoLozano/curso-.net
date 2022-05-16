using WebApiAutores.Validaciones;
using System.ComponentModel.DataAnnotations;


namespace WebApiAutores.Dtos

{
    public class LibroCreacionDTO

    {     
        [StringLength(maximumLength:250, ErrorMessage ="El campo {0} no debe tener mas de {1} caracteres")]
        [PrimeraMayusculaAttribute]
        public string Titulo { get; set; }
    }


}
