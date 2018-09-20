using System;
using System.Collections.Generic;
using System.Text;

namespace AddressAPI3.Domain
{
    public class AddressGroup : Address
    {
        public string FormattedText { get; set; }
        public int Count { get; set; }
    }
}
