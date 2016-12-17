using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Covalition.Igorary.Mvc.Extensions
{
    public static class ModelStateDictionaryExtensions
    {
        public static IEnumerable<string> Errors(this ModelStateDictionary modelState) {
            return modelState.Values
                .SelectMany(m => m.Errors)
                .Select(e => " " + e.ErrorMessage);
        }
    }
}