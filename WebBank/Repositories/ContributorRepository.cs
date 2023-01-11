using WebBank.Context;
using WebBank.Entities;

namespace WebBank.Repositories
{
    public class ContributorRepository
    {
        private readonly AppDbContext _context;

        public ContributorRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Contributor> GetAllContributors()
        {
            return _context.Contributors.ToList();
        }
    }
}