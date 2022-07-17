using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools.Exceptions
{
    public class ModelException
    {
        public int ErrorCode { get; set; }
        public IEnumerable<string> Messages { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }

        public ModelException()
        {
            Messages = new List<string>();
        }
    }
}
