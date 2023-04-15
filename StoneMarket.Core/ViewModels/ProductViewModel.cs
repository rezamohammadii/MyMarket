using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneMarket.Core.ViewModels
{
    public class ProductViewModel
    {

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
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public List<IFormFile> Pictures { get; set; } = new List<IFormFile>();

    }
}
