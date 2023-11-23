using NetSwissTools.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace NetSwissTools.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class IsAnyOfAttribute : ValidationAttribute
    {
        private readonly Regex IsAnyOf;

        public IsAnyOfAttribute(string regex)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            IsAnyOf = new Regex($"^{regex}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            ErrorMessageResourceName = "ValueInvalid";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }

        public override bool IsValid(object value)
        {
            if ((value ?? "").ToString().IsEmpty())
                return true;

            if (IsAnyOf.IsMatch((value ?? "").ToString()))
                return true;

            return false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value ?? "").ToString().IsEmpty())
                return ValidationResult.Success;

            if (IsAnyOf.IsMatch((value ?? "").ToString()))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
