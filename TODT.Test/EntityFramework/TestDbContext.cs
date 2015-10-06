using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using TOTD.EntityFramework;

namespace TODT.Test.EntityFramework
{
    [DbConfigurationType(typeof(EntityFrameworkConfiguration))]
    public class TestDbContext : DbContext
    {
        public TestDbContext()
            : base()
        {
            Database.SetInitializer<TestDbContext>(null);
            Database.Log = Console.WriteLine;
        }

        public IDbSet<TestEntity> TestEntities
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestEntity>().Property(x => x.AliasedColumn).HasColumnName("Alias").HasMaxLength(TestEntity.AliasedColumnLength);
            modelBuilder.Entity<TestEntity>().HasKey(x => x.ID).Property(x => x.ID).IsIdentity();

            modelBuilder.Entity<TestAliasedEntity>().ToTable("AliasedTable").HasKey(x => new
            {
                x.ID1,
                x.ID2
            });

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

}
