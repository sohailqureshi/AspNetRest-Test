using MoneyBox.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBox.Tests
{
  public class TestTransactionContext : ITransactionContext
  {
    public TestTransactionContext()
    {
      this.Transactions = new TestTransactionDbSet();
    }

    public DbSet<Transaction> Transactions { get; set; }

    public int SaveChanges()
    {
      return 0;
    }

    public void MarkAsModified(Transaction item) { }
    public void Dispose() { }
  }
}
