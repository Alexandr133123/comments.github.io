using Comments.Core.DTOs;
using Comments.Core.Interfaces.IService;
using Comments.Infrastructure.Interfaces.IRepository;
using Comments.Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;

namespace Comments.Core.Managers
{
    public class FileStorageFormatManager
    {
        public List<FileStorage> FormatFilesToBase64(List<IFormFile> uploadedFiles)
        {
            List<FileStorage> files = new List<FileStorage>();

            using (MemoryStream stream = new MemoryStream())
            {
                foreach (IFormFile formFile in uploadedFiles)
                {
                    FileStorage file = new FileStorage();

                     formFile.CopyTo(stream);
                    byte[] fileData = stream.ToArray();
                    string fileDataBase64 = Convert.ToBase64String(fileData);

                    file.FileData = fileDataBase64;
                    files.Add(file);
                }
            }

            return files;
        }

    }
}
