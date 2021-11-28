using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Advertise.Property.Services
{
    public interface IFilesService
    {
        IAsyncEnumerable<string> SaveFiles(IEnumerable<IFormFile> formFiles, string path);

        Stream GetFile(string root, string file);
    }
}
