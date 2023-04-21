﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StoneMarket.AccessLayer.Entity
{

    
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; } = null!;

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public string? Date { get; set; } = GetPersianDate.GetPersianTime();

        public string? Name { get; set; }

        public string? SeoDescrption { get; set; }
        public string? SeoTitle { get; set; }

        public int Price { get; set; }

        public int DeletePrice { get; set; }

        public int Exist { get; set; }
        public int Weight { get; set; }
        public int Size { get; set; }

        public bool NotShow { get; set; }

        public string? Color { get; set; }

        public string? Description { get; set; }

        public string? MoreDescription { get; set; }

        public string? Material { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }


        public virtual ICollection<ProductGallery>? ProductGalleries { get; set; }
       

        //public virtual ICollection<ProductField> ProductFields { get; set; }

        //public virtual ICollection<ProductSeen> ProductSeens { get; set; }
    }

}
