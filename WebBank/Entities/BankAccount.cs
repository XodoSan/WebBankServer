namespace WebBank.Entities
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        public Guid BankId { get; set; }
        public Bank Bank { get; set; }
        public Guid ContributorId { get; set; }
        public Contributor Contributor { get; set; }
        public Guid RateId { get; set; }
        public Rate Rate { get; set; }
        public int Count { get; set; }
        public DateTime AccountOpeningDate { get; set; }
        public ICollection<Operation>? SenderOperations { get; set; }
        public ICollection<Operation>? RecipientOperations { get; set; }
    }
}