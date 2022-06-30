using ContabilidadHogar.Database;
using ContabilidadHogar.Interfaces;
using ContabilidadHogar.Models;

namespace ContabilidadHogar.Repository
{
    public class MoneyControlRepository : IMoneyControlDatabaseTransactions
    {
        ContextMoney context;
        public MoneyControlRepository(ContextMoney contextNew)
        {
            context = contextNew;
        }
        public void Create(MoneyControl Transaction)
        {
            Transaction.AmountTransaction = Transaction.IncomeTransaction == true ? Transaction.AmountTransaction : (Transaction.AmountTransaction * -1);
            Transaction.BalanceTransaction = BalanceSum(Transaction.AmountTransaction);
            context.Add(Transaction);
            context.SaveChanges();
        }

        public void Delete(MoneyControl Transaction)
        {
            context.Remove(Transaction);
            context.SaveChanges();
        }

        public List<MoneyControl> Read()
        {
            return context.RegistryMoneyControl.OrderByDescending(x=>x.TransactionDateTime).ToList();
        }

        public MoneyControl Read(Guid guid)
        {
            return context.RegistryMoneyControl.Find(guid);
        }

        public void Update(MoneyControl Transaction)
        {
            Transaction.AmountTransaction = Transaction.IncomeTransaction == true ? Transaction.AmountTransaction : (Transaction.AmountTransaction * -1);
            //Transaction.BalanceTransaction = BalanceSum(Transaction.AmountTransaction);
            context.Update(Transaction);
            context.SaveChanges();
            Transaction.BalanceTransaction = BalanceSum(Transaction.AmountTransaction);
            context.Update(Transaction);
            context.SaveChanges();
        }
        private double BalanceSum(double AmountTransaction)
        {
            var ListTransaction = Read();
            double SumList = ListTransaction.Sum(x => x.AmountTransaction);
            return SumList + AmountTransaction;
        }
    }
}