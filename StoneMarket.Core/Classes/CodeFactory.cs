using StoneMarket.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
namespace StoneMarket.Core.Classes
{
    public class CodeFactory
    {
        public static string UploadedFile(CategoryViewModel model, string uploadsFolder)
        {
            string? uniqueFileName = null;

            if (model.Picture != null)
            {
                
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Picture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Picture.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }


    }
}
