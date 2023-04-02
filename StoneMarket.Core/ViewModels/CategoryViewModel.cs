using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace StoneMarket.Core.ViewModels
{
    public class CategoryViewModel
    {
        [Display(Name = "نام دسته")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string Name { get; set; } = null!;

        [Display(Name = "نام دسته")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string? ParentCategory { get; set; }

        [Display(Name = "آیکون")]
        [MaxLength(20, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        [Required(ErrorMessage = "نباید بدون مقدار باشد")]
        public string? Icon { get; set; }
    }
}
