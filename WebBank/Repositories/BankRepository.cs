using WebBank.Context;
using WebBank.Entities;

namespace WebBank.Repositories
{
    public class BankRepository
    {
        private readonly AppDbContext _context;

        public BankRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Bank> GetAllBanks()
        {
            return _context.Banks.ToList();
        }

        public void AddBank(Bank bankDto)
        {
            var bankNames = _context.Banks.Select(x => x.Name).ToList();
            if (bankNames.Contains(bankDto.Name))
            {
                throw new Exception($"Bank with name: {bankDto.Name} already exist");
            }

            bankDto.Id = Guid.NewGuid();
            _context.Banks.Add(bankDto);
            _context.SaveChanges();
        }

        public void DeleteBank(Guid id)
        {
            var currentBank = _context.Banks.FirstOrDefault(x => x.Id == id);
            if (currentBank == null)
            {
                throw new Exception($"Bank with id: {id} does not exist");
            }

            var currentBankAccounts = _context.BankAccounts.Where(x => x.BankId == id);
            if (currentBankAccounts.Count() > 0)
            {
                throw new Exception($"Bank with name: {currentBank.Name} has a link with some bank account");
            }

            _context.Banks.Remove(currentBank);
            _context.SaveChanges();
        }
    }
}