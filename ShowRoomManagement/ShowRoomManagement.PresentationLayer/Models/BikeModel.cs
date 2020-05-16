using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRoomManagement.PresentationLayer.Models
{
    public class BikeModel
    {
        public int BikeId { get; set; }
        public string BikeName { get; set; }

        public double BikePrice { get; set; }
        public int DiscBrakes { get; set; }
        public int Milage { get; set; }
        public int BikeCC { get; set; }
        public byte[] BikeImages { get; set; }

        public HttpPostedFileBase File { get; set; }
        public string BrandName { get; set; }


    }
}