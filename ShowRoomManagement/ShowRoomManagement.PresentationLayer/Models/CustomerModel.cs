using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRoomManagement.PresentationLayer.Models
{
    public class CustomerModel
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}