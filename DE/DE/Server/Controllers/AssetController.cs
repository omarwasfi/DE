using System;
using AutoMapper;
using DE.Server.DataModels;
using DE.Server.Services.Classes;
using DE.Server.Services.Interfaces;
using DE.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Win32;

namespace DE.Server.Controllers
{
	[ApiController]
	[Route("api/asset")]
	public class AssetController : ControllerBase
	{
		private IAsset _asset { get; set; }
		private IStoredFile _file { get; set; }
		private IPicture _picture { get; set; }
		private readonly IMapper _mapper;


		public AssetController(IAsset asset, IStoredFile file,  IMapper mapper, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
		{
			this._asset = asset;
			this._file = file;
			this._picture = new Picture(hostingEnvironment);
			this._mapper = mapper;
		}

		[HttpPost]
		[Route("AddNewAsset")]
		public async Task<AssetDataViewModel> AddNewAsset(AssetDataViewModel asset)
        {
			AssetDataModel newAssetDataModel = _mapper.Map<AssetDataModel>(asset);
			AssetDataModel assetDataModel =   await _asset.AddAsset(newAssetDataModel);

			AssetDataViewModel assetDataViewModel = _mapper.Map<AssetDataViewModel>(assetDataModel);
			
			return assetDataViewModel;
        }

		[HttpPut]
		[Route("UpdateAsset")]
		public async Task<AssetDataViewModel> UpdateAsset(AssetDataViewModel asset)
		{
			AssetDataModel newAssetDataModel = _mapper.Map<AssetDataModel>(asset);
			AssetDataModel assetDataModel = await _asset.UpdateAsset(newAssetDataModel);

			AssetDataViewModel assetDataViewModel = _mapper.Map<AssetDataViewModel>(assetDataModel);

			return assetDataViewModel;
		}

		[HttpPost]
		[Route("UpdatePictureForAsset")]
		public async Task<string>UpdatePictureForAsset([FromForm] string assetId, [FromForm] IFormFile file = null)
		{
			string fileName = file.FileName.Substring(0, file.FileName.IndexOf("."));
			string fileExtension = file.FileName.Substring( file.FileName.IndexOf(".") + 1);

			
			StoredFileDataModel storedFilePicture = await _file.StoreFile(file, fileName,fileExtension);

			AssetDataModel selectedAsset  =await _asset.GetAsset(assetId);
			selectedAsset.Picure = storedFilePicture;
			

			await _asset.UpdateAsset(selectedAsset);

			return await _picture.GetPictureBase64(storedFilePicture);
		}


		[HttpPost]
		[Route("AddDoocumentForAsset")]
		public async Task<string> AddDoocumentForAsset([FromForm] string assetId, [FromForm] IFormFile file)
		{
			string fileName = file.FileName.Substring(0, file.FileName.IndexOf("."));
			string fileExtension = file.FileName.Substring(file.FileName.IndexOf(".") + 1);
			StoredFileDataModel storedFileDocument = await _file.StoreFile(file, fileName, fileExtension);

			AssetDataModel selectedAsset = await _asset.GetAsset(assetId);

			if(selectedAsset.Decuments != null && selectedAsset.Decuments.Count > 0)
            {
				selectedAsset.Decuments.Add(storedFileDocument);
            }
            else
            {
				selectedAsset.Decuments = new List<StoredFileDataModel>();

				selectedAsset.Decuments.Add(storedFileDocument);

			}


			await _asset.UpdateAsset(selectedAsset);

			return storedFileDocument.Id;

		}


		[HttpGet]
		[Route("GetAssetDocumentsIds")]
		public async Task<List<string>> GetAssetDocumentsIds(string assetId)
		{
			return await _asset.GetDocumentsIds(assetId);

		}

		

		[HttpGet]
		[Route("DownloadDocumentFileById")]
		public async Task<IActionResult> DownloadDocumentFileById(string id)
		{
			StoredFileDataModel storedFile = await _file.GetStoredFile(id);

			var path = storedFile.Path + storedFile.FileName +"." + storedFile.FileExtention;

			var fileStream = System.IO.File.OpenRead(path);
			string fileType = GetMimeTypeForFileExtension(path);
			return File(fileStream, fileType,storedFile.FileName + "." + storedFile.FileExtention);
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

