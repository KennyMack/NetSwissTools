using NetSwissTools.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace NetSwissTools.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class OnlyIntegerAttribute : ValidationAttribute
    {
        public OnlyIntegerAttribute()
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "OnlyNumbers";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
        public override bool IsValid(object value)
        {
            if ((value ?? "").ToString().IsEmpty())
                return true;

            return int.TryParse(value.ToString(), out _);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value ?? "").ToString().IsEmpty())
                return ValidationResult.Success;

            if (int.TryParse(value.ToString(), out _))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class OnlyDecimalAttribute : ValidationAttribute
    {
        public OnlyDecimalAttribute()
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "OnlyNumbers";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
        public override bool IsValid(object value)
        {
            if ((value ?? "").ToString().IsEmpty())
                return true;

            return decimal.TryParse(value.ToString(), out _);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value ?? "").ToString().IsEmpty())
                return ValidationResult.Success;

            if (decimal.TryParse(value.ToString(), out _))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class OnlyDateTimeAttribute : ValidationAttribute
    {
        public OnlyDateTimeAttribute()
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "OnlyDate";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
        public override bool IsValid(object value)
        {
            if ((value ?? "").ToString().IsEmpty())
                return true;

            return DateTime.TryParse(value.ToString(), out _);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value ?? "").ToString().IsEmpty())
                return ValidationResult.Success;

            if (DateTime.TryParse(value.ToString(), out _))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}
