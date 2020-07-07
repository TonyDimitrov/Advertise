using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Advertise.Api.Services
{
    public interface IFilesService
    {
        IEnumerable<string> SaveFiles(IEnumerable<IFormFile> formFiles, string path);
    }
}
