using ShowRoomManagement.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRoomManagement.PresentationLayer.Models
{
    public class TransactionModel
    {
        public int TransactionId { get; set; }


        public string CustomerId { get; set; }


        public int BikeId { get; set; }

        public double? BikePrice { get; set; }
        public double? EMI { get; set; }
        public int? EMIMonths { get; set; }
        public Customer Customers { get; set; }
        public Bike Bikes { get; set; }

    }
}