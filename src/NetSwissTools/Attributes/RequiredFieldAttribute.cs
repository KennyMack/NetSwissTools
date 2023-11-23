using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NetSwissTools.Attributes
{
    public class RequiredFieldAttribute : RequiredAttribute
    {
        public RequiredFieldAttribute()
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            AllowEmptyStrings = false;
            ErrorMessageResourceName = "RequiredDefault";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class RequiredGroupFieldAttribute : RequiredAttribute
    {
        private string[] _Properies;

        public RequiredGroupFieldAttribute(string[] properties)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            _Properies = properties;
            AllowEmptyStrings = false;
            ErrorMessageResourceName = "RequiredDefault";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<string> lstProperties = new List<string>();
            var hasAnyValue = false;
            var objType = validationContext.ObjectType;
            var objInstance = validationContext.ObjectInstance;
            foreach (var item in _Properies)
            {
                var property = objType.GetProperty(item);

                if (property == null)
                    throw new ArgumentException("Property with this name not found");

                var ValueProp = property.GetValue(objInstance);

                if (!hasAnyValue)
                    hasAnyValue = ValueProp != null &&
                        !string.IsNullOrEmpty(ValueProp.ToString()) &&
                        !string.IsNullOrWhiteSpace(ValueProp.ToString());

                lstProperties.Add((ValueProp ?? "").ToString());
            }

            if (hasAnyValue &&
                string.IsNullOrEmpty((value ?? "").ToString()) &&
                string.IsNullOrWhiteSpace((value ?? "").ToString()) &&
                lstProperties.Any(r => string.IsNullOrEmpty(r) || string.IsNullOrWhiteSpace(r)))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
