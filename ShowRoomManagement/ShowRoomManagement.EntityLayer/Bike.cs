using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomManagement.EntityLayer
{
    [Table("Bikes")]
    public class Bike:IComparable<Bike>
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BikeId { get; set; }
        public string BikeName { get; set; }

        public double BikePrice { get; set; }
        public int DiscBrakes { get; set; }
        public int Milage { get; set; }
        public int BikeCC { get; set; }
        public byte[] BikeImages { get; set; }

        [ForeignKey("Brands")]
        public string BrandName { get; set; }

        public Brand Brands { get; set; }
        public List<Transaction> Transactions { get; set; }

        public int CompareTo(Bike other)
        {
            if (BikeName.CompareTo(other.BikeName) > 0)
                return 1;
            else if (BikeName.CompareTo(other.BikeName) < 0)
                return -1;
            else
                return 0;
        }
    }
}
