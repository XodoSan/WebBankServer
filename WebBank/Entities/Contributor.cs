namespace WebBank.Entities
{
    public class Contributor
    {
        public Guid Id { get; set; }
        public string FIO { get; set; }
        public string PostName { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<BankAccount>? BankAccounts { get; set; }
    }
}