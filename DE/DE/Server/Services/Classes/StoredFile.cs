using System;
using DE.Server.DataModels;
using DE.Server.DBContext;
using DE.Server.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace DE.Server.Services.Classes
{
	public class StoredFile : IStoredFile
	{
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private DEDbContext _dEDbContext;

        public StoredFile(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, DEDbContext dEDbContext)
		{
            this._hostingEnvironment = hostingEnvironment;
            this._dEDbContext = dEDbContext;
		}

       

        public async Task<StoredFileDataModel> StoreFile(IFormFile file, string fileName, string fileExtension)
        {
            StoredFileDataModel storedFile = new StoredFileDataModel();
            await _dEDbContext.StoredFiles.AddAsync(storedFile);
            await _dEDbContext.SaveChangesAsync();

            storedFile.FileName = storedFile.Id + fileName ;
            storedFile.FileExtention = fileExtension;
            storedFile.Path = _hostingEnvironment.WebRootPath + "/App_Data/Pictures/" ;
            string saveToPath = storedFile.Path + storedFile.FileName + "." + fileExtension;

            await saveTheFileToTheLocalStorage(file, saveToPath);


            _dEDbContext.Update(storedFile);
            await _dEDbContext.SaveChangesAsync();

            return storedFile;
            
        }

        private async Task saveTheFileToTheLocalStorage(IFormFile formFile, string saveToPath)
        {

            IFormFile file = formFile;

            using (Stream fs = new FileStream(saveToPath
                , FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                file.CopyTo(fs);
                fs.Close();

            }
        }

        public async Task<StoredFileDataModel> GetStoredFile(string Id)
        {
            return await _dEDbContext.StoredFiles.FindAsync(Id);
        }


        public async Task<FileContentResult> DownloadFile(string id)
        {
            StoredFileDataModel storedFile = await _dEDbContext.StoredFiles.FindAsync(id);

            string path = storedFile.Path + storedFile.FileName + "." + storedFile.FileExtention;

            string fileType = GetMimeTypeForFileExtension(path);

            var myfile = await System.IO.File.ReadAllBytesAsync(storedFile.Path + storedFile.FileName + "." + storedFile.FileExtention);


            return new FileContentResult(myfile, fileType);

        }

        private string GetMimeTypeForFileExtension(string filePath)
        {
            const string DefaultContentType = "application/octet-stream";

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(filePath, out string contentType))
            {
                contentType = DefaultContentType;
            }

            return contentType;
        }
    }
}

