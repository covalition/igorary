using System;
using System.Collections.Generic;
using System.Text;

namespace Covalition.Igorary.Utils.Extensions
{
    public static class IntExtensions
    {
        public static string ToRoman(this int number, bool upperCase) {
            if (number < 0)
                throw new ArgumentOutOfRangeException("number", number, "Liczba musi być większa od zera.");
            string[] romans = new string[] { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

            int[] numbers = new int[] { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
            int j = 12;
            string result = "";
            while (number != 0) {
                if (number >= numbers[j]) {
                    number -= numbers[j];
                    result += romans[j];
                }
                else
                    j--;
            }
            if (!upperCase)
                result = result.ToLower();
            return result;
        }

    }
}
