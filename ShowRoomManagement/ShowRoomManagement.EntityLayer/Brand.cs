using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomManagement.EntityLayer
{
    [Table("Brands")]
    public class Brand
    {
        [Key]

        public string BrandName { get; set; }


        public List<Bike> Bikes { get; set; }

    }
}
