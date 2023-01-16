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

        public void AddContributor(Contributor contributorDto)
        {
            var contributorFios = _context.Contributors.Select(x => x.FIO).ToList();
            if (contributorFios.Contains(contributorDto.FIO))
            {
                throw new Exception($"Contributor with fio: {contributorDto.FIO} already exist");
            }

            contributorDto.Id = Guid.NewGuid();
            contributorDto.Birthday = contributorDto.Birthday.ToUniversalTime();
            _context.Contributors.Add(contributorDto);
            _context.SaveChanges();
        }

        public void DeleteContributor(Guid id)
        {
            var currentContributor = _context.Contributors.FirstOrDefault(x => x.Id == id);
            if (currentContributor == null)
            {
                throw new Exception($"Contributor with id: {id} does not exist");
            }

            var currentBankAccounts = _context.BankAccounts.Where(x => x.ContributorId == id);
            if (currentBankAccounts.Count() > 0)
            {
                throw new Exception($"Contributor with fio: {currentContributor.FIO} has a link with some bank account");
            }

            _context.Contributors.Remove(currentContributor);
            _context.SaveChanges();
        }
    }
}