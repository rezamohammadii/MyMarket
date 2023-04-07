using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoneMarket.AccessLayer.Entity
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام دسته")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string Name { get; set; } = null!;

        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        [Display(Name = "تصویر")]
        [MaxLength(30, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string? Picture { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        public string? Description { get; set; }

        [Display(Name = "توضیحات بیشتر")]
        public string? MoreDescription { get; set; }


        public string? SeoTitle { get; set; }
        public string? SeoDescrption { get; set; }
        public string? Title { get; set; }

        public virtual Category? Parent { get; set; } 

        public virtual ICollection<StoreCategory>? StoreCategories { get; set; }

        public virtual ICollection<Product>? Products { get; set; }

    }
}
