using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Advertise.Property.Services
{
    public interface IFilesService
    {
        IAsyncEnumerable<string> SaveFiles(IEnumerable<IFormFile> formFiles, string path);
    }
}
