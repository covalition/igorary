using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covalition.Igorary.Blazor.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LinkAttribute : Attribute
    {
        public string FieldId { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string IdParamName { get; set; }

        /// <summary>
        /// Should the query string for this link be accompanied by information about the address from which the linked page will be called?
        /// </summary>
        public bool AttachReturnUrl { get; set; }

        public LinkAttribute() {
            IdParamName = "id";
            FieldId = "Id";
            ActionName = "Edit";
        }
    }
}