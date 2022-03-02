using System;
using DE.Server.DataModels;
using DE.Server.Services.Interfaces;

namespace DE.Server.Services.Classes
{
	public class Picture :  IPicture
	{
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public Picture(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
		{
            this._hostingEnvironment = hostingEnvironment;
		}

        public async Task<string> GetPictureBase64(StoredFileDataModel storedFile)
        {
            byte[] fileBytes = await convertLocalFileToArrOfByte(
              storedFile.Path +
              storedFile.FileName +
              "." + storedFile.FileExtention
             );

            return "data:image/"
                    + $"{storedFile.FileExtention};"
                    + "base64, "
                    + Convert.ToBase64String(fileBytes);
        }

        private async Task<byte[]> convertLocalFileToArrOfByte(string localPath)
        {
            using (FileStream fs = new FileStream(localPath, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(localPath);
                fs.Read(bytes, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                return bytes;

            }
        }
    }
}

