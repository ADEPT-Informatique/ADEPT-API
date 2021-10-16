using ADEPT_API.Dto.Errors;
using ADEPT_API.LIBRARY.Validations.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ADEPT_API.LIBRARY.Validations.Commons
{
    public class AdeptRequiredAttribute : RequiredAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = ValidationResult.Success;

            if (!base.IsValid(value))
            {
                var error = new Error
                {
                    ErrorCode = $"{ValidationErrors.ERR_REQUIRED}_{validationContext.MemberName.ToUpper()}",
                    Message = $"Le champ {validationContext.MemberName} doit avoir une valeur."
                };
                result = new ValidationResult(JsonConvert.SerializeObject(error));
            }

            return result;
        }
    }
}
