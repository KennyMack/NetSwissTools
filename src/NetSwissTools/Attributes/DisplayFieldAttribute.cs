using System;
using System.ComponentModel;
using System.Resources;
using System.Runtime.CompilerServices;

namespace NetSwissTools.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class DisplayFieldAttribute : DisplayNameAttribute
    {
        public DisplayFieldAttribute([CallerMemberName] string propertyName = "")
        {
            if (DefaultAttributeConfiguration.FieldsNameResource == null)
                throw new ArgumentNullException("[DefaultAttributeConfiguration.FieldsNameResource] has not been loaded");

            try
            {
                var resource = new ResourceManager(DefaultAttributeConfiguration.FieldsNameResource)
                {
                    IgnoreCase = true
                };
                DisplayNameValue = resource.GetString(propertyName) ?? propertyName;
            }
            catch (Exception)
            {
                DisplayNameValue = propertyName;
            }
        }
    }
}
