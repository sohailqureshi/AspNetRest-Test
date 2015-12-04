using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MoneyBox.Models;

namespace MoneyBox.Areas.Api.Controllers
{
  /// <summary>
  ///  Money-Box CRUD for Transactions
  /// </summary>
  public class TransactionsController : ApiController
  {
    // modify the type of the db field
    private ITransactionContext db = new TransactionContext();

    /// <summary>
    /// Default Controller
    /// </summary>
    public TransactionsController()
    {
    }

    /// <summary>
    /// Repository Controller
    /// </summary>
    public TransactionsController(ITransactionContext context)
    {
      db = context;
    }

    /// <summary>
    /// Gets all transactions
    /// </summary>
    /// <returns></returns>
    public IHttpActionResult GetAllTransactions()
    {
      var transactions = db.Transactions.ToList();
      return Ok(transactions);
    }

    /// <summary>
    /// Gets single trasaction
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public IHttpActionResult GetTransaction(int id)
    {
      Transaction item = db.Transactions.Find(id);
      if (item == null)
      {
        return BadRequest("Transaction not found");
      }
      return Ok(item);
    }

    /// <summary>
    /// Puts a single transaction
    /// </summary>
    /// <param name="id"></param>
    /// <param name="transaction"></param>
    public IHttpActionResult PutTransaction(long id, Transaction transaction)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      transaction.TransactionId = id;
      if (transaction == null)
      {
        return BadRequest("Transaction not found");
      }

      try
      {
        //db.Entry(transaction).State = EntityState.Modified;
        db.MarkAsModified(transaction);
        db.SaveChanges();
      }
      catch
      {
        return BadRequest(ModelState);       
      }

      return Ok();
    }

    /// <summary>
    /// Posts a single transaction
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public IHttpActionResult PostTransaction(Transaction item)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      item = db.Transactions.Add(item);
      db.SaveChanges();

      return CreatedAtRoute("DefaultApi", new { id = item.TransactionId }, item);
    }

    /// <summary>
    /// Deletes a single transaction
    /// </summary>
    /// <param name="id"></param>
    public IHttpActionResult DeleteTransaction(int id)
    {
      var transaction = db.Transactions.Find(id);
      if (transaction==null)
      {
        return BadRequest("Transaction not found");
      }

      db.Transactions.Remove(transaction);
      db.SaveChanges();

      return Ok();
    }
  }
}