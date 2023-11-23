using System;
using System.ComponentModel.DataAnnotations;

namespace NetSwissTools.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class LongGreaterThan : RangeAttribute
    {
        private long _minimum;
        public LongGreaterThan(long minimum) :
            base(minimum + 1, long.MaxValue)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            _minimum = minimum;
            ErrorMessageResourceName = "GreaterThan";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(base.ErrorMessageString, name, _minimum);
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class IntegerGreaterThan : RangeAttribute
    {
        private int _minimum;
        public IntegerGreaterThan(int minimum) :
            base(minimum + 1, int.MaxValue)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");


            _minimum = minimum;
            ErrorMessageResourceName = "GreaterThan";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(base.ErrorMessageString, name, _minimum);
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class SbyteGreaterThan : RangeAttribute
    {
        private sbyte _minimum;
        public SbyteGreaterThan(sbyte minimum) :
            base(minimum + 1, sbyte.MaxValue)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");


            _minimum = minimum;
            ErrorMessageResourceName = "GreaterThan";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(base.ErrorMessageString, name, _minimum);
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class ShortGreaterThan : RangeAttribute
    {
        private short _minimum;
        public ShortGreaterThan(short minimum) :
            base(minimum + 1, short.MaxValue)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            _minimum = minimum;
            ErrorMessageResourceName = "GreaterThan";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(base.ErrorMessageString, name, _minimum);
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class DecimalGreaterThan : RangeAttribute
    {
        private double _minimum;
        public DecimalGreaterThan(double minimum) :
            base(minimum, double.MaxValue)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            _minimum = minimum;
            ErrorMessageResourceName = "GreaterThan";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }

        public override bool IsValid(object value) =>
            Convert.ToDouble(value) > _minimum;

        public override string FormatErrorMessage(string name) =>
            string.Format(base.ErrorMessageString, name, _minimum);
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class FloatGreaterThan : RangeAttribute
    {
        private double _minimum;
        public FloatGreaterThan(float minimum) :
            base(minimum, double.MaxValue)
        {
            if (DefaultAttributeConfiguration.ValidationMessagesResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.ValidationMessagesResource] has not been loaded");

            _minimum = minimum;
            ErrorMessageResourceName = "GreaterThan";
            ErrorMessageResourceType = DefaultAttributeConfiguration.ValidationMessagesResource;
        }

        public override bool IsValid(object value) => 
            Convert.ToDouble(value) > _minimum;

        public override string FormatErrorMessage(string name) =>
            string.Format(base.ErrorMessageString, name, _minimum);
    }
}
