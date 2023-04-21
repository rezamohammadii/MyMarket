using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneMarket.AccessLayer.Entity
{
    public class Uploader
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImgAddress { get; set; } = string.Empty;
    }
}
