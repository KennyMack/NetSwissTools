using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools.System
{
    public class TaskResult
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public bool IsError { get; set; }

        public TaskResult()
        {

        }

        public TaskResult(string Key, string Description, bool IsError = false)
        {
            this.Key = Key;
            this.Description = Description;
            this.IsError = IsError;
        }
    }
}
