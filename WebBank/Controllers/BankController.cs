using Microsoft.AspNetCore.Mvc;
using WebBank.Dto;
using WebBank.Entities;
using WebBank.Repositories;

namespace WebBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly BankRepository _bankRepository;
        private readonly BankAccountRepository _bankAccountRepository;
        private readonly RateRepository _rateRepository;
        private readonly ContributorRepository _contributorRepository;

        public BankController(BankRepository bankRepository, BankAccountRepository bankAccountRepository, RateRepository rateRepository, ContributorRepository contributorRepository)
        {
            _bankRepository = bankRepository;
            _bankAccountRepository = bankAccountRepository;
            _rateRepository = rateRepository;
            _contributorRepository = contributorRepository;
        }

        [HttpGet]
        public List<Bank> GetAllBanks()
        {
            return _bankRepository.GetAllBanks();
        }

        [HttpGet("Rate")]
        public List<Rate> GetAllRates()
        {
            return _rateRepository.GetAllRates();
        }

        [HttpGet("Contributor")]
        public List<Contributor> GetAllContributors()
        {
            return _contributorRepository.GetAllContributors();
        }

        [HttpGet("BankAccount")]
        public List<BankAccount> GetAllBankAccounts()
        {
            return _bankAccountRepository.GetAllBankAccounts();
        }

        [HttpPost("BankAccount")]
        public void AddBankAccount([FromBody] BankAccountDto account)
        {
            _bankAccountRepository.AddBankAccount(account);
        }
    }
}