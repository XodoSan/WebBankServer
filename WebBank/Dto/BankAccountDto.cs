namespace WebBank.Dto
{
    public class BankAccountDto
    {
        public Guid Id { get; set; }
        public Guid BankId { get; set; }
        public Guid ContributorId { get; set; }
        public Guid RateId { get; set; }
        public int Count { get; set; }
        public DateTime AccountOpeningDate { get; set; }
    }
}