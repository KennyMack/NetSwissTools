using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace NetSwissTools.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class PhoneFieldAttribute : ValidationAttribute
    {
        private static readonly Regex PhoneRegex = new Regex(@"^(\(\d{2,3}\)\s\d{4,5}\-\d{4})$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public PhoneFieldAttribute()
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "PhoneInvalid";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty((value ?? "").ToString()))
                return true;

            if (PhoneRegex.IsMatch((value ?? "").ToString()))
                return true;

            return false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty((value ?? "").ToString()))
                return ValidationResult.Success;

            if (PhoneRegex.IsMatch((value ?? "").ToString()))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class CellPhoneFieldAttribute : ValidationAttribute
    {
        private static readonly Regex PhoneRegex = new Regex(@"^(\(\d{2,3}\)\s\d{5}\-\d{4})$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public CellPhoneFieldAttribute()
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "CellphoneInvalid";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }

        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty((value ?? "").ToString()))
                return true;

            if (PhoneRegex.IsMatch((value ?? "").ToString()))
                return true;


            return false;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty((value ?? "").ToString()))
                return ValidationResult.Success;

            if (PhoneRegex.IsMatch((value ?? "").ToString()))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
