using ADEPT_API.DATACONTRACTS.Dto.Errors;
using ADEPT_API.DATACONTRACTS.Validations.Enums;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace ADEPT_API.DATACONTRACTS.Validations.Commons
{
    public class AdeptValidGuidAttribute : ValidationAttribute
    {
        public bool RefuseEmptyGuid { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = ValidationResult.Success;

            if (value is { })
            {
                if (value.GetType() != typeof(Guid))
                {
                    var stringValue = value as string;
                    if (!Guid.TryParse(stringValue, out var guid))
                    {
                        var error = new Error
                        {
                            ErrorCode = $"{ValidationErrors.ERR_INVALIDGUID}_{validationContext.MemberName}",
                            Message = $"Le champ {validationContext.MemberName} doit contenir un Guid valide"
                        };
                        result = new ValidationResult(JsonConvert.SerializeObject(error));
                    }
                    else if (this.RefuseEmptyGuid && guid.Equals(Guid.Empty))
                    {
                        var error = new Error
                        {
                            ErrorCode = $"{ValidationErrors.ERR_INVALIDGUID}_{validationContext.MemberName}",
                            Message = $"Le champ {validationContext.MemberName} doit contenir un Guid valide et qui ne doit pas être égale à '{Guid.Empty}'"
                        };
                        result = new ValidationResult(JsonConvert.SerializeObject(error));
                    }
                }
                else
                {
                    if (this.RefuseEmptyGuid && ((Guid)value).Equals(Guid.Empty))
                    {
                        var error = new Error
                        {
                            ErrorCode = $"{ValidationErrors.ERR_INVALIDGUID}_{validationContext.MemberName}",
                            Message = $"Le champ {validationContext.MemberName} doit contenir un Guid valide et qui ne doit pas être égale à '{Guid.Empty}'"
                        };
                        result = new ValidationResult(JsonConvert.SerializeObject(error));
                    }
                }
            }

            return result;
        }
    }
}
