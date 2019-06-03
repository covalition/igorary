using System;
using System.Collections.Generic;
using System.Text;

namespace Covalition.Igorary.Blazor.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SortAttribute: Attribute
    {
        public string SortId { get; set; }
    }
}
