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

        public void AddRate(Rate rateDto)
        {
            var rateNames = _context.Rates.Select(x => x.Name).ToList();
            if (rateNames.Contains(rateDto.Name))
            {
                throw new Exception($"Rate with name: {rateDto.Name} already exist");
            }

            rateDto.Id = Guid.NewGuid();
            _context.Rates.Add(rateDto);
            _context.SaveChanges();
        }

        public void DeleteRate(Guid id)
        {
            var currentRate = _context.Rates.FirstOrDefault(x => x.Id == id);
            if (currentRate == null)
            {
                throw new Exception($"Rate with id: {id} does not exist");
            }

            var currentBankAccounts = _context.BankAccounts.Where(x => x.RateId == id);
            if (currentBankAccounts.Count() > 0)
            {
                throw new Exception($"Rate with name: {currentRate.Name} has a link with some bank account");
            }

            _context.Rates.Remove(currentRate);
            _context.SaveChanges();
        }
    }
}