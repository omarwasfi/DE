using System;
using DE.Server.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace DE.Server.Services.Interfaces
{
	public interface IStoredFile
	{
		public Task<StoredFileDataModel> StoreFile(IFormFile file, string fileName, string fileExtension);

		public Task<FileContentResult> DownloadFile(string id);

		public Task<StoredFileDataModel> GetStoredFile(string Id);


	}
}
	
