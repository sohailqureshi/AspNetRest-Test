using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoneyBox.Models
{
  public class TransactionContext : DbContext, ITransactionContext
  {
    public TransactionContext() : base("name=TransactionContext")
    {
    }
    public DbSet<Transaction> Transactions { get; set; }

    public void MarkAsModified(Transaction item)
    {
      Entry(item).State = EntityState.Modified;
    }
  }
}
