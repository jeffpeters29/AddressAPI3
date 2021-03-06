﻿using AddressAPI3.Domain;
using Newtonsoft.Json;

namespace AddressAPI3.Application.Helpers
{
    public static class AddressExtensions
    {
        public static bool IsPostcodeLength(this string inputString)
        {
            inputString = inputString.RemoveWhiteSpace();

            return inputString.Length > 5;
        }

        public static string ToFormattedString(this AddressData addressData)
        {
            // StartText : for specific postcodes
            var organisation = (!string.IsNullOrEmpty(addressData.Organisation)) ? addressData.Organisation.Trim() + ", " : string.Empty;
            var number = (addressData.Number != 0) ? addressData.Number.ToString().Trim() + " " : string.Empty;
            var startText = (organisation + number).Trim() + " ";

            // Count : for grouped postcodes
            var countText = (addressData.Count > 0)
                            ? " - " + $"{addressData.Count} " + ((addressData.Count == 1) ? "address" : "addresses")
                            : string.Empty;


            return $"{addressData.Postcode} : {startText}{addressData.Street}, {addressData.Town}" + countText
                 + $"<span style='display:none'>{JsonConvert.SerializeObject(addressData)}</span>";
        }
    }
}
