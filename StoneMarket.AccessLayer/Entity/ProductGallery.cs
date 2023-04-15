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
        public string ProductCode { get; set; } = null!;
        public string? Img { get; set; }

    }
}
