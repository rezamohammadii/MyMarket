using System;
using System.Collections.Generic;
using System.Text;

using StoneMarket.AccessLayer.Entity;

namespace StoneMarket.Core.ViewModels
{
    public class SearchCategoryViewModel
    {
        public List<Product>? FillProducts { get; set; }
        
        public List<Category>? FillCategories { get; set; }
                              
        public Category? FillParentCategory { get; set; }
                              
        public Category?  FillSelectCategory { get; set; }
                              
        public List<Store>? FillStores { get; set; }
        
        public List<Brand>? FillBrands { get; set; }
    }
}
