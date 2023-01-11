using Microsoft.EntityFrameworkCore;
using WebBank.Context;
using WebBank.Dto;
using WebBank.Entities;

namespace WebBank.Repositories
{
    public class BankAccountRepository
    {
        private readonly AppDbContext _context;

        public BankAccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<BankAccount> GetAllBankAccounts()
        {
            return _context.BankAccounts
                .Include(x => x.Bank)
                .Include(x => x.Rate)
                .Include(x => x.Contributor)
                .ToList();
        }

        public void AddBankAccount(BankAccountDto account)
        {
            var currentEntity = _context.BankAccounts.FirstOrDefault(x => x.BankId == account.BankId &&
            x.ContributorId == account.ContributorId &&
            x.RateId == account.RateId);

            if (currentEntity != null)
            {
                throw new Exception("Account of this contributor with this parameters already exist");
            }

            BankAccount result = new BankAccount 
            { 
                BankId = account.BankId, 
                ContributorId = account.ContributorId, 
                RateId = account.RateId, 
                Count = account.Count, 
                AccountOpeningDate = account.AccountOpeningDate
            };

            result.Id = Guid.NewGuid();
            result.AccountOpeningDate = DateTime.UtcNow;
            _context.BankAccounts.Add(result);
            _context.SaveChanges();
        }
    }
}