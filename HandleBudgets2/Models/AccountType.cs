using HandleBudgets2.Validations;
using System.ComponentModel.DataAnnotations;

namespace HandleBudgets2.Models
{
    public class AccountType //: IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        //[StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres.")]
        //[Display(Name = "Nombre del tipo de cuenta")]
        //[FirstCapitalLetter]
        public string Name { get; set; }

        public int UserId { get; set; }
        public int Order { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Name != null && Name.Length > 0)
        //    {
        //        var firstLetter = Name[0].ToString();
        //        if (firstLetter != firstLetter.ToUpper())
        //        {
        //            yield return new ValidationResult("La primer letra debe ser mayusculita", new[] { nameof(Name) });
        //        }
        //    }
        //}
    }
}
