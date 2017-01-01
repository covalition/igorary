using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Covalition.Igorary.Mvc.Extensions
{
    public static class DictionaryExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(this IDictionary<int, string> lookupData) {
            return lookupData.Select(di => new SelectListItem { Value = di.Key.ToString(), Text = di.Value });
        }
    }
}
