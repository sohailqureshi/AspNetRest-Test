using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBox.Models
{
  public interface ITransactionContext : IDisposable
  {

    DbSet<Transaction> Transactions { get; }
    int SaveChanges();
    void MarkAsModified(Transaction item);
  }
}
