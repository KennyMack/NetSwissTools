using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools.Attributes
{
    public static class DefaultAttributeConfiguration
    {
        public static Type FieldsNameResource { get; set; } = typeof(Resources.FieldsNameResource);
        public static Type ValidationMessagesResource { get; set; } = typeof(Resources.ValidationMessagesResource);
    }
}
