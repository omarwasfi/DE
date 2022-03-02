using System;
using DE.Server.DataModels;
using Microsoft.EntityFrameworkCore;


namespace DE.Server.DBContext
{
    [System.Data.Entity.DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]

    public class DEDbContext : DbContext
	{
        public DbSet<AssetDataModel> Assets { get; set; }
        public DbSet<StoredFileDataModel> StoredFiles { get; set; }

        public DEDbContext(DbContextOptions<DEDbContext> options) : base(options)
        {


        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(true);
        }
    }
}

