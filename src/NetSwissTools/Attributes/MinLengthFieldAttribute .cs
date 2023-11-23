using System;
using System.ComponentModel.DataAnnotations;

namespace NetSwissTools.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class MinLengthFieldAttribute : MinLengthAttribute
    {
        public MinLengthFieldAttribute(int length) : base(length)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min1LengthFieldAttribute : MinLengthAttribute
    {
        public Min1LengthFieldAttribute() : base(1)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min2LengthFieldAttribute : MinLengthAttribute
    {
        public Min2LengthFieldAttribute() : base(2)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min4LengthFieldAttribute : MinLengthAttribute
    {
        public Min4LengthFieldAttribute() : base(4)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min8LengthFieldAttribute : MinLengthAttribute
    {
        public Min8LengthFieldAttribute() : base(8)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min10LengthFieldAttribute : MinLengthAttribute
    {
        public Min10LengthFieldAttribute() : base(10)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min20LengthFieldAttribute : MinLengthAttribute
    {
        public Min20LengthFieldAttribute() : base(20)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min36LengthFieldAttribute : MinLengthAttribute
    {
        public Min36LengthFieldAttribute() : base(36)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min40LengthFieldAttribute : MinLengthAttribute
    {
        public Min40LengthFieldAttribute() : base(40)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min60LengthFieldAttribute : MinLengthAttribute
    {
        public Min60LengthFieldAttribute() : base(60)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min120LengthFieldAttribute : MinLengthAttribute
    {
        public Min120LengthFieldAttribute() : base(120)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min255LengthFieldAttribute : MinLengthAttribute
    {
        public Min255LengthFieldAttribute() : base(255)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Min2000LengthFieldAttribute : MinLengthAttribute
    {
        public Min2000LengthFieldAttribute() : base(2000)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MinCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
}
