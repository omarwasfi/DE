using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DE.Server.DataModels
{
	public class StoredFileDataModel

	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string? Path { get; set; }

        public string? FileName { get; set; }

        public string? FileExtention { get; set; }
    }
}