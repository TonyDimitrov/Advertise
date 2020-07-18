using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertise.Property.Services
{
    public class FilesService : IFilesService
    {
        public async IAsyncEnumerable<string> SaveFiles(IEnumerable<IFormFile> formFiles, string path)
        {
            if (formFiles == null || formFiles.Count() == 0)
            {
                yield return null;
            }
            else
            {

                foreach (var file in formFiles)
                {
                    var uniqueName = Guid.NewGuid().ToString();

                    var fullPath = Path.Combine(path, uniqueName);
                    var extension = file.Name
                            .Split('.', StringSplitOptions.RemoveEmptyEntries)
                            .LastOrDefault();
                    Path.ChangeExtension(fullPath, extension);

                    using (var stream = File.Create(fullPath))
                    {
                        await file.CopyToAsync(stream);
                    }

                    yield return fullPath;
                }
            }
        }
    }
}
