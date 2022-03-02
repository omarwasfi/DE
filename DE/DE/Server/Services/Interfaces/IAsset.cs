using System;
using DE.Server.DataModels;

namespace DE.Server.Services.Interfaces
{
	public interface IAsset
	{
		public Task<AssetDataModel> AddAsset(AssetDataModel asset);
		public Task<AssetDataModel> UpdateAsset(AssetDataModel asset);
		public Task<AssetDataModel> GetAsset(string Id);
		public Task<List<string>> GetDocumentsIds(string Id);

	}
}

