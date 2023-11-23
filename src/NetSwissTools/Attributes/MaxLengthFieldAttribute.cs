using System;
using System.ComponentModel.DataAnnotations;

namespace NetSwissTools.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class MaxLengthFieldAttribute : MaxLengthAttribute
    {
        public MaxLengthFieldAttribute(int length) : base(length)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max1LengthFieldAttribute : MaxLengthAttribute
    {
        public Max1LengthFieldAttribute() : base(1)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max2LengthFieldAttribute : MaxLengthAttribute
    {
        public Max2LengthFieldAttribute() : base(2)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max4LengthFieldAttribute : MaxLengthAttribute
    {
        public Max4LengthFieldAttribute() : base(4)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max8LengthFieldAttribute : MaxLengthAttribute
    {
        public Max8LengthFieldAttribute() : base(8)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max10LengthFieldAttribute : MaxLengthAttribute
    {
        public Max10LengthFieldAttribute() : base(10)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max20LengthFieldAttribute : MaxLengthAttribute
    {
        public Max20LengthFieldAttribute() : base(20)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max36LengthFieldAttribute : MaxLengthAttribute
    {
        public Max36LengthFieldAttribute() : base(36)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max40LengthFieldAttribute : MaxLengthAttribute
    {
        public Max40LengthFieldAttribute() : base(40)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max60LengthFieldAttribute : MaxLengthAttribute
    {
        public Max60LengthFieldAttribute() : base(60)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max120LengthFieldAttribute : MaxLengthAttribute
    {
        public Max120LengthFieldAttribute() : base(120)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max255LengthFieldAttribute : MaxLengthAttribute
    {
        public Max255LengthFieldAttribute() : base(255)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max500LengthFieldAttribute : MaxLengthAttribute
    {
        public Max500LengthFieldAttribute() : base(500)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class Max2000LengthFieldAttribute : MaxLengthAttribute
    {
        public Max2000LengthFieldAttribute() : base(2000)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "MaxCharacters";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
}
