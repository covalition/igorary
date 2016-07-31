using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Igorary.Utils.Extensions
{
    public static class NullableDecimalExtensions
    {
        public static string ToString(this decimal? d, string format) {
            if (d != null)
                return d.Value.ToString(format);
            else
                return null;
        }
    }
}
