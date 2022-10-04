using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Validations
{
    public class DOBValidation : ValidationAttribute
    {
/*        public DOBValidation(DateTime dob) => DOB = dob;
        public DateTime DOB { get; }*/

        public string GetDOBErrorMessage() =>
      $"Date of Birth must be no later than ";

             protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
        {
            var user = (UserInfo)validationContext.ObjectInstance;
            var year = ((DateTime)value!).Year;
/*            var month = ((DateTime)value!).Month;
            var day = ((DateTime)value!).Day;*/

            if (year >=2002)
            {
                return new ValidationResult(GetDOBErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
