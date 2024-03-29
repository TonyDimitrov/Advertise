﻿using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
                    var extension = Path.GetExtension(file.FileName);
                    if (extension == null)
                    {
                        yield return null;
                    }
                    var newQniqueFileName = Path.ChangeExtension(uniqueName, extension);
                    var fullPath = Path.Combine(path, newQniqueFileName);

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var stream = File.Create(fullPath))
                    {

                        await file.CopyToAsync(stream);
                    }

                    yield return newQniqueFileName;
                }
            }
        }

        public Stream GetFile(string root, string file)
        {
            return new FileStream(Path.Combine(root, file), FileMode.Open);
        }
    }
}
