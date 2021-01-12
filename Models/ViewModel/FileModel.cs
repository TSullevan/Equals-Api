using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Equals_Api.Models.ViewModel
{
    public class FileModel
    {
        [Display(Name = "document")]
        public IFormFile Document { get; set; }
    }
}
