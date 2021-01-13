using System;
using System.Threading.Tasks;
using Equals_Api.Models.ServiceModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Equals_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;

        private readonly IServiceProvider _provider;

        public FileController(ILogger<FileController> logger, IServiceProvider provider)
        {
            _logger = logger;
            _provider = provider;
        }

        [HttpPost]
        public async Task PostAsync([FromForm] IFormFile file)
        {
            FileService service = _provider.GetRequiredService<FileService>();

            string text = await service.ReadFileAsync(file);
            
            service.SaveFile(text);
        }
    }
}
