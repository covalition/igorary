using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igorary.Utils.Extensions
{
    public static class ExceptionExtensions
    {
        public static T GetInner<T>(this Exception ex) where T: Exception {
            Exception inner = ex;
            while (inner != null && !(inner is T))
                inner = inner.InnerException;
            return inner as T;
        }
    }
}
