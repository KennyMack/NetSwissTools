using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools.System
{
    public class TaskResultObject<T>
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public bool IsError { get; set; }

        public T DataObject { get; private set; }

        public TaskResultObject()
        {

        }

        public TaskResultObject(string Key, string Description,
            T DataObject,
            bool IsError = false)
        {
            this.Key = Key;
            this.Description = Description;
            this.IsError = IsError;
            this.DataObject = DataObject;
        }

        public void SetResultObject(T obj) =>
            this.DataObject = obj;
    }
}
