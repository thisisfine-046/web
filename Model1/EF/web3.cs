namespace Model1.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class web3 : DbContext
    {
        public web3()
            : base("name=web3")
        {
        }

        public virtual DbSet<ulogin> ulogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
