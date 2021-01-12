using System.IO;
using System.Threading.Tasks;
using Equals_Api.Extensions;
using Equals_Api.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Equals_Api.Models.ServiceModel
{
    public class FileService
    {
        public async Task<string> ReadFileAsync([FromForm] IFormFile file)
        {
            string text = string.Empty;
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                byte[] byteArray = stream.ToArray();

                text = System.Text.Encoding.Default.GetString(byteArray);
            }
            return text;
        }

        private string SelectBusinessType(string text)
        {
            string[] businessTypes = 
            {
                BusinessType.UflaCard,
                BusinessType.FagammonCard
            };

            foreach(string type in businessTypes)
            {
                if(text.ThereIs(type))
                {
                    return type;
                }
            }
            return string.Empty;
        }

        public void SaveFile(string text)
        {
            string businessType = SelectBusinessType(text);

            if(businessType.Equals(BusinessType.UflaCard))
            {
                
            }

            if(businessType.Equals(BusinessType.FagammonCard))
            {
                
            }
        }
    }
}