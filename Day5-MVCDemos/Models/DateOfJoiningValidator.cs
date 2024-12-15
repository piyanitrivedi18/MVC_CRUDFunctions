using System.ComponentModel.DataAnnotations;

namespace Day5_MVCDemos.Models
{
    public class DateOfJoiningValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime dt =  Convert.ToDateTime(value);
            if (dt != null)
            {
                if (dt >= Convert.ToDateTime("12/12/2020") && dt <= DateTime.Parse("12/12/2024"))
                {
                    return ValidationResult.Success;
                }
            }

        return new ValidationResult(ErrorMessage ?? "DOJ shub in Range");
        }

          

    }
}
