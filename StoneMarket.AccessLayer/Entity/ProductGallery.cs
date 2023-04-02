using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneMarket.AccessLayer.Entity
{
    public class ProductGallery
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Img { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; } 


    }
}
