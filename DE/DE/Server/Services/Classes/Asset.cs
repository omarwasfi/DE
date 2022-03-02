using System;
using DE.Server.DataModels;
using DE.Server.DBContext;
using DE.Server.Services.Interfaces;

namespace DE.Server.Services.Classes
{
    public class Asset : IAsset
	{
        private DEDbContext _dEDbContext;

        public Asset(DEDbContext dEDbContext)
		{
            this._dEDbContext = dEDbContext;
		}

        public async Task<AssetDataModel> AddAsset(AssetDataModel asset)
        {
            await _dEDbContext.Assets.AddAsync(asset);
            await _dEDbContext.SaveChangesAsync();

            return asset;
        }

        public async Task<AssetDataModel> GetAsset(string Id)
        {
            return await _dEDbContext.Assets.FindAsync(Id);
        }

        public async Task<List<string>> GetDocumentsIds(string Id)
        {
            AssetDataModel selectedAsset = await GetAsset(Id);
            List<string> Ids = new List<string>();
            foreach(StoredFileDataModel storedFile in selectedAsset.Decuments)
            {
                Ids.Add(storedFile.Id);
            }
            return Ids;
        }

        public async Task<AssetDataModel> UpdateAsset(AssetDataModel asset)
        {
             _dEDbContext.Update(asset);
            await _dEDbContext.SaveChangesAsync();

            return asset;
        }
    }
}

