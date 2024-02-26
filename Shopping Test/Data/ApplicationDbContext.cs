
namespace Shopping_Test.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>()
                .Property(a => a.DisplayName)
                .HasComputedColumnSql("[FirstName]+' '+ [LastName]");

            builder.Entity<UserProducts>().HasKey(a => new { a.ApplicationUserId, a.ProductId });
            builder.Entity<UserProducts>()
                .HasOne(p => p.Product).WithMany(u => u.UserProducts)
                .HasForeignKey(p => p.ProductId);
            builder.Entity<UserProducts>()
              .HasOne(p => p.ApplicationUser).WithMany(u => u.UserProducts)
              .HasForeignKey(p => p.ApplicationUserId);
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<AgeStage> AgeStages { get; set; }
        public DbSet<ClothesClassification> ClothesClassifications { get; set; }
        public DbSet<HumanClass> HumanClass { get; set; }
        public DbSet<Marka> Markas { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PaymentDetail> paymentDetails { get; set; }
        public DbSet<RevesationSystem> RevesationSystems { get; set; }
        public DbSet<UserProducts> UserProducts { get; set; }

    }
}
