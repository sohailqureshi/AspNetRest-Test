using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MoneyBox.Models
{
  public interface ITransactionRepository
  {
    IEnumerable<Transaction> GetAll();
    Transaction Get(int id);
    Transaction Add(Transaction item);
    void Remove(int id);
    bool Update(Transaction item);
  }
}
