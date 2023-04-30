using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneMarket.Core.ViewModels
{
    public class UploaderViewModel
    {
        public string Name { get; set; } = string.Empty;
        public IFormFile? Picture { get; set; }
    }
}
