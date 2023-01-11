namespace WebBank.Entities
{
    public class Operation
    {
        public Guid Id { get; set; }
        public Guid SenderBankAccountId { get; set; }
        public BankAccount SenderBankAccount { get; set; }
        public Guid RecipientBankAccountId { get; set; }
        public BankAccount RecipientBankAccount { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}