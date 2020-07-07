using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Advertise.Api.Services
{
    public class FilesService : IFilesService
    {
        public IEnumerable<string> SaveFiles(IEnumerable<IFormFile> formFiles, string path)
        {
            throw new NotImplementedException();
        }
    }
}
