using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration;
using EntityFramework.Interceptors.Tests.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EntityFramework.Interceptors.Tests
{
    public class Product
    {
        public int Id { get; set; }
        public string RegionCode { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.RegionCode).IsRequired().HasMaxLength(8);
            HasIndex(x => x.CategoryId);
            HasIndex(x => x.RegionCode);
        }
    }

    public class TestDbContext : DbContext, IHintDbContext
    {
        static TestDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestDbContext, Configuration>());
        }

        public TestDbContext() : base("DefaultConnection") { }

        public DbSet<Product> Products { get; set; }
        private HintAccessor _hintAssessor = new HintAccessor();
        public HintAccessor HintAssessor { get => _hintAssessor; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Configurations.Add(new ProductConfiguration());
        }
    }
}
