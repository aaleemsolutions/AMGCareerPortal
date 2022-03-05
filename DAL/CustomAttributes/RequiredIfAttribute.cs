using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CareerPortal.CustomAttributes
{
    public class RequiredIfAttribute: ValidationAttribute
    {
        public string PropertyName { get; set; }
        public object Value { get; set; }
        //[RequiredIf(nameof(IntEvDecisionId), "1", ErrorMessage = "Joining Date Is Required If Candidate Selected")]
        public RequiredIfAttribute(string propertyName, object value, string errorMessage = "")
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            Value = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var type = instance.GetType(); 
            var proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (proprtyvalue.ToString() == Value.ToString() && value == null)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}