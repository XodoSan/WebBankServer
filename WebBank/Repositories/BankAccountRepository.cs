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

        public List<BankAccount> GetFilteredBankAccounts()
        {
            return _context.BankAccounts
                .Include(x => x.Bank)
                .Include(x => x.Rate)
                .Include(x => x.Contributor)
                .OrderBy(x => x.Contributor.FIO)
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

        public void DeleteBankAccount(Guid id)
        {
            var currentBankAccount = _context.BankAccounts.FirstOrDefault(x => x.Id == id);
            if (currentBankAccount == null)
            {
                throw new Exception($"Account with id: {id} does not exist");
            }

            _context.BankAccounts.Remove(currentBankAccount);
            _context.SaveChanges();
        }

        public void UpdateAccount(BankAccountDto accountDto)
        {
            var currentBankAccount = _context.BankAccounts.FirstOrDefault(x => x.Id == accountDto.Id);
            if (currentBankAccount == null)
            {
                throw new Exception($"Account with id: {accountDto.Id} does not exist");
            }

            currentBankAccount.BankId = accountDto.BankId;
            currentBankAccount.ContributorId = accountDto.ContributorId;
            currentBankAccount.RateId = accountDto.RateId;
            _context.SaveChanges();
        }
    }
}