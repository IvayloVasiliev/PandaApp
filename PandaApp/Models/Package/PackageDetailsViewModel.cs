using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PandaApp.Models.Package
{
    public class PackageDetailsViewModel
    {
        public string ShippingAddress { get; set; }
        public string Status { get; set; }
        public string EstimatedDeliveryDate { get; set; }
        public double Weight { get; set; }
        public string Recipient { get; set; }
        public string Description { get; set; }


    }
}
