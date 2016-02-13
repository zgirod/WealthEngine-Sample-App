using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WE.Api.Web.Models
{
    public class ByAddressModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }


    }
}