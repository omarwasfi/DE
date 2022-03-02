using System;
using DE.Server.DataModels;

namespace DE.Server.Services.Interfaces
{
	public interface IPicture
	{
		public Task<string> GetPictureBase64(StoredFileDataModel storedFile);

		
	}
}

