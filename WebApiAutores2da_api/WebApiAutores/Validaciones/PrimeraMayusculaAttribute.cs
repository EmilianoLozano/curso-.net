using System.ComponentModel.DataAnnotations;
namespace WebApiAutores.Validaciones;


// CREAMOS UNA VALIDACION ESPECIFICA PARA SER USADA DONDE NECESITEMOS INSTANCIANDOLA
public class PrimeraMayusculaAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if(value == null || string.IsNullOrEmpty(value.ToString()))
        {
            return ValidationResult.Success;
        }

        // obtengo la primera letra del string
        var primeraLetra = value.ToString()[0].ToString();

        if(primeraLetra != primeraLetra.ToUpper())
        {
            return new ValidationResult("La primera letra debe ser mayuscula");
        }
        return ValidationResult.Success;
    }

}
