using NetSwissTools.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hino.Salesforce.Infra.Cross.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class LongRangeFieldAttribute : RangeAttribute
    {
        public LongRangeFieldAttribute(long minimum, long maximum) :
            base(minimum, maximum)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "RangeOnlyInteger";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class IntegerRangeFieldAttribute : RangeAttribute
    {
        public IntegerRangeFieldAttribute(int minimum, int maximum) :
            base(minimum, maximum)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "RangeOnlyInteger";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class DecimalRangeFieldAttribute : RangeAttribute
    {
        public DecimalRangeFieldAttribute(double minimum, double maximum) :
            base(minimum, maximum)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            ErrorMessageResourceName = "RangeOnlyDecimal";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }
    }
}
