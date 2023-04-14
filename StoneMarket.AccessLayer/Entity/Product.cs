using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
namespace StoneMarket.AccessLayer.Entity
{

    
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string? Date { get; set; } = HandleDate.GetPersianTime();

        [Display(Name = "نام محصول")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نباید بیش تر از {1} کاراکتر باشد")]
        public string? Name { get; set; }

        public string? SeoDescrption { get; set; }
        public string? SeoTitle { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }

        [Display(Name = "قیمت قبل")]
        public int DeletePrice { get; set; }

        [Display(Name = "موجودی")]
        public int Exist { get; set; }

        [Display(Name = "عدم نمایش")]
        public bool NotShow { get; set; }

        [Display(Name = "سایر توضیحات")]
        [DataType(DataType.MultilineText)]
        public string? Desc { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }


        public virtual ICollection<ProductGallery>? ProductGalleries { get; set; }
        public virtual ICollection<Atterbuit>? Atterbuits { get; set; }

        //public virtual ICollection<ProductField> ProductFields { get; set; }

        //public virtual ICollection<ProductSeen> ProductSeens { get; set; }
    }

    public class HandleDate 
    { 
        public static string GetPersianTime()
        {
            PersianCalendar pc = new PersianCalendar();
            string date = pc.GetYear(DateTime.Now).ToString("0000") + "/" + pc.GetMonth(DateTime.Now).ToString("00") +
                             "/" + pc.GetDayOfMonth(DateTime.Now).ToString("00");
            return date;
        }
    }

}
