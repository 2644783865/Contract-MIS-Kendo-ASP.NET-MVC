using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Misi.MVC.ViewModels.Shared
{
    public class FileUploadViewModel
    {
        public int Id { get; set; }

        public string UploadFileName { get; set; }
        
        public string FilePath { get; set; }
        
    }
}