using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DE.Server.DataModels
{
	public class AssetDataModel
	{
        public AssetDataModel()
        {
            this.Decuments = new HashSet<StoredFileDataModel>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public DateTime AssetDateOfService { get; set;  }

        public string AssetSizeUnit { get; set; }

        public virtual StoredFileDataModel Picure { get; set; }

        public virtual ICollection<StoredFileDataModel> Decuments { get; set; }

    }
}

