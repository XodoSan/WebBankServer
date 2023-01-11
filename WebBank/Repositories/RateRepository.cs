using WebBank.Context;
using WebBank.Entities;

namespace WebBank.Repositories
{
    public class RateRepository
    {
        private readonly AppDbContext _context;

        public RateRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Rate> GetAllRates()
        {
            return _context.Rates.ToList();
        }
    }
}