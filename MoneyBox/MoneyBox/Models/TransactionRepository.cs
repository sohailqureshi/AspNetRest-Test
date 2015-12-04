using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyBox.Models
{
  public class TransactionRepository :ITransactionRepository
  {
    private List<Transaction> transactions = new List<Transaction>();
    private int _nextId = 1;

    /// <summary>
    /// 
    /// </summary>
    public TransactionRepository()
    {
      Add(new Transaction { Description = "Computer", TransactionAmount = 999.99M });
      Add(new Transaction { Description = "Laptop", TransactionAmount = 1600.00M });
      Add(new Transaction { Description = "Mobile Phone", TransactionAmount = 449.99M});
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Transaction> GetAll()
    {
      return transactions;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Transaction Get(int id)
    {
      return transactions.Find(p => p.TransactionId == id);
    }

    public Transaction Add(Transaction item)
    {
      if (item == null)
      {
        throw new ArgumentNullException("item");
      }

      item.TransactionId = _nextId++;
      transactions.Add(item);
      return item;
    }

    public void Remove(int id)
    {
      transactions.RemoveAll(p => p.TransactionId == id);
    }

    public bool Update(Transaction item)
    {
      if (item == null)
      {
        throw new ArgumentNullException("item");
      }
      int index = transactions.FindIndex(p => p.TransactionId == item.TransactionId);
      if (index == -1)
      {
        return false;
      }
      transactions.RemoveAt(index);
      transactions.Add(item);
      return true;
    }
  }
}
