using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class EndPointAttribute : Attribute
    {
        public EndPointAttribute(string pEndPoint)
        {
            EndPoint = pEndPoint;
        }

        public string EndPoint
        {
            get;
            private set;
        }
    }
}
