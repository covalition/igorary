using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covalition.Igorary.Mvc.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LinkAttribute : Attribute
    {
        public string FieldId { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string IdParamName { get; set; }

        /// <summary>
        /// Czy do query string dla tego linku ma być dołączona informacja o adresie, z którego wywoływana bedzie linkowana strona
        /// </summary>
        public bool AttachReturnUrl { get; set; }

        public LinkAttribute() {
            IdParamName = "id";
            FieldId = "Id";
            ActionName = "Edit";
        }

        //public override void Process(ModelMetadata modelMetaData) {
        //    modelMetaData.AdditionalValues.Add("Link", new LinkMetadata
        //    {
        //        ActionName = ActionName,
        //        ControllerName = ControllerName,
        //        FieldId = FieldId,
        //        IdParamName = IdParamName,
        //        AttachReturnUrl = AttachReturnUrl
        //    });
        //}
    }
}