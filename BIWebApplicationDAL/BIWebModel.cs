namespace BIWebApplicationDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BIWebModel : DbContext
    {
        public BIWebModel()
            : base("name=BIWebModel")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<tblCompany> tblCompanies { get; set; }
        public virtual DbSet<tblGroupMenu> tblGroupMenus { get; set; }
        public virtual DbSet<tblGroup> tblGroups { get; set; }
        public virtual DbSet<tblQueryColumn> tblQueryColumns { get; set; }
        public virtual DbSet<tblQueryConnection> tblQueryConnections { get; set; }
        public virtual DbSet<tblQueryDetail> tblQueryDetails { get; set; }
        public virtual DbSet<tblQueryMain> tblQueryMains { get; set; }
        public virtual DbSet<tblQueryParameter> tblQueryParameters { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblUsersQueryParameters> tblUsersQueryParameters { get; set; }
        public virtual DbSet<tblQueryParametersBridge> tblQueryParametersBridges { get; set; }
        public virtual DbSet<tblUsersCount> tblUsersCounts { get; set; }

        public virtual DbSet<tblQueryColumnsDataFormat> tblQueryColumnsDataFormat { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetRole>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserClaim>()
                .Property(e => e.ClaimType)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserClaim>()
                .Property(e => e.ClaimValue)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserClaim>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserLogin>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserLogin>()
                .Property(e => e.LoginProvider)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUserLogin>()
                .Property(e => e.ProviderKey)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<tblQueryParametersBridge>().ToTable("tblQueryParametersBridge");
            modelBuilder.Entity<tblQueryColumnsDataFormat>().ToTable("tblQueryColumnsDataFormat");
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetRoles)
                .WithMany(e => e.AspNetUsers)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("UserId").MapRightKey("RoleId"));


        }
    }
}
