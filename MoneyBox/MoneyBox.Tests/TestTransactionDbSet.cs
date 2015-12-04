using MoneyBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBox.Tests
{
  public class TestTransactionDbSet : TestDbSet<Transaction>
  {
    public override Transaction Find(params object[] keyValues)
    {
      return this.SingleOrDefault(transaction => transaction.TransactionId == (int)keyValues.Single());
    }
  }
}
