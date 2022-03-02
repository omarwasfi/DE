using System;
namespace DE.Shared
{
	public class AssetDataViewModel
	{

        public string Id { get; set; }

        public string AssetId { get; set; }

        public string AssetIdCode { get; set; }

        public string AssetNameArabic { get; set; }

        public string AssetNameEnglish { get; set; }

        public string AssetStatus { get; set; }

        public string AssetGroup { get; set; }

        public string AssetType { get; set; }

        public string AssetClass { get; set; }

        public string AssetHeight { get; set; }

        public string AssetLength { get; set; }

        public string AssetWidth { get; set; }

        public DateTime AssetDateOfService { get; set; }

        public string AssetSizeUnit { get; set; }

        public StoredFileDataViewModel Picure { get; set; }

        public List<StoredFileDataViewModel> Decuments { get; set; }
    }
}

