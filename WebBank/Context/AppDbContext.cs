using Microsoft.EntityFrameworkCore;
using WebBank.Entities;

namespace WebBank.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>()
                .HasOne(x => x.Bank)
                .WithMany(x => x.BankAccounts)
                .HasForeignKey(x => x.BankId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BankAccount>()
                .HasOne(x => x.Contributor)
                .WithMany(x => x.BankAccounts)
                .HasForeignKey(x => x.ContributorId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BankAccount>()
                .HasOne(x => x.Rate)
                .WithMany(x => x.BankAccounts)
                .HasForeignKey(x => x.RateId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Operation>()
                .HasOne(x => x.SenderBankAccount)
                .WithMany(x => x.SenderOperations)
                .HasForeignKey(x => x.SenderBankAccountId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Operation>()
                .HasOne(x => x.RecipientBankAccount)
                .WithMany(x => x.RecipientOperations)
                .HasForeignKey(x => x.RecipientBankAccountId)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Contributor> Contributors { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}