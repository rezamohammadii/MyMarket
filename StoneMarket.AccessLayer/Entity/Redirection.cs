using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneMarket.AccessLayer.Entity
{
    public class Redirection
    {
        [Key]
        public int Id { get; set; }
        public string OldUrl { get; set; } = null!;
        public string NewUrl { get; set; } = null!;
        public string Createdate { get; set; } = GetPersianDate.GetPersianTime();
    }
}
