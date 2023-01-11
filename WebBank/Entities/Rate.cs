namespace WebBank.Entities
{
    public class Rate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }   
        public string Information { get; set; }
        public ICollection<BankAccount>? BankAccounts { get; set; }
    }
}