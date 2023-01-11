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
    }
}