using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AddressAPI3.Domain;

namespace AddressAPI3.Application.Helpers
{
    public static class AddressExtensions
    {
        public static bool IsPostcodeLength(this string inputString)
        {
            inputString = inputString.RemoveWhiteSpace();

            return inputString.Length > 5; 
        }

        public static string ToFormattedString(this AddressGroup addressGroup)
        {
            return $"{addressGroup.Postcode} -  {addressGroup.Street} {addressGroup.Town} : " +
                   $"{addressGroup.Count} " + ((addressGroup.Count == 1) ? " address" : " addresses");
        }
    }
}
