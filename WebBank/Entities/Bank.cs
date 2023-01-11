namespace WebBank.Entities
{
    public class Bank
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<BankAccount>? BankAccounts { get; set; }
    }
}