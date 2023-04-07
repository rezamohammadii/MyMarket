using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StoneMarket.Core.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام دسته")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Name { get; set; } = null!;

        [Display(Name = "نام دسته")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string? ParentId { get; set; }

        [Display(Name = "تصویر")]
        public IFormFile? Picture { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        public string? Description { get; set; }

        [Display(Name = "توضیحات بیشتر")]
        public string? MoreDescription { get; set; }

        public string? SeoTitle { get; set; }
        public string? SeoDescrption { get; set; }
        public string? Title { get; set; }

       
    }
}
