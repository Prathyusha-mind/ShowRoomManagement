using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomManagement.EntityLayer
{

    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [ForeignKey("Customers")]
        public string CustomerId { get; set; }

        [ForeignKey("Bikes")]
        public int BikeId { get; set; }

        public double? BikePrice { get; set; }
        public double? EMI { get; set; }
        public int? EMIMonths { get; set; }
        public Customer Customers { get; set; }
        public Bike Bikes { get; set; }


    }
}
