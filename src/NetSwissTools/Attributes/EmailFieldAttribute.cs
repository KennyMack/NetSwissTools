using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace NetSwissTools.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class EmailFieldAttribute : ValidationAttribute
    {
        private static readonly Regex EmailRegex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public EmailFieldAttribute()
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "InvalidEmail";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty((value ?? "").ToString()))
                return true;

            if (EmailRegex.IsMatch((value ?? "").ToString()))
                return true;

            return false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty((value ?? "").ToString()))
                return ValidationResult.Success;

            if (EmailRegex.IsMatch((value ?? "").ToString()))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
