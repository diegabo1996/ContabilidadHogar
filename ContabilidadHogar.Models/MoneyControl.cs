namespace ContabilidadHogar.Models
{
    public class MoneyControl
    {
        public Guid IdTransaction { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public bool IncomeTransaction { get; set; }
        public double AmountTransaction { get; set; }
        public double BalanceTransaction { get; set; }
    }
}