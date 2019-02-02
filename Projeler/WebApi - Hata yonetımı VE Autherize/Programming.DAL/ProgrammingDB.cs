namespace Programming.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProgrammingDB : DbContext
    {
        public ProgrammingDB()
            : base("name=ProgrammingDB")
        {
        }

        public virtual DbSet<kullanicilar> kullanicilar { get; set; }
        public virtual DbSet<duyurular> duyurular { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
