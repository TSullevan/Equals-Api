using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Equals_Api.Models.ServiceModel
{
    public class FileService
    {
        public async Task<string> ReadFileAsync([FromForm] IFormFile file)
        {
            string text = "";
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                byte[] byteArray = stream.ToArray();

                text = System.Text.Encoding.Default.GetString(byteArray);
            }
            return text;
        }
    }
}