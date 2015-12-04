using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyBox.Models;
using MoneyBox.Areas.Api.Controllers;
using System.Web.Http.Results;
using System.Web.Http;
using System.Net;

namespace MoneyBox.Tests
{
  [TestClass]
  public class TestTransactionsController
  {
    [TestMethod]
    public void GetAllTransactions_ShouldReturnAllTransactions()
    {
      var context = new TestTransactionContext();
      context.Transactions.Add(new Transaction { TransactionId = 1, Description = "Demo1", TransactionAmount = 1.23M });
      context.Transactions.Add(new Transaction { TransactionId = 2, Description = "Demo2", TransactionAmount = 2.34M });
      context.Transactions.Add(new Transaction { TransactionId = 3, Description = "Demo3", TransactionAmount = 34.45M });
      context.Transactions.Add(new Transaction { TransactionId = 4, Description = "Demo4", TransactionAmount = 456.78M });
      var controller = new TransactionsController(context);

      var result = controller.GetAllTransactions() as OkNegotiatedContentResult<List<Transaction>>;
      Assert.AreEqual(4, result.Content.Count);
    }

    [TestMethod]
    public void GetTransaction_ShouldReturnTransactionWithSameID()
    {
      var context = new TestTransactionContext();
      context.Transactions.Add(new Transaction { TransactionId = 1, Description = "Demo1", TransactionAmount = 1.23M });

      var controller = new TransactionsController(context);
      var result = controller.GetTransaction(1) as OkNegotiatedContentResult<Transaction>;

      Assert.IsNotNull(result);
      Assert.AreEqual(1, result.Content.TransactionId);
    }


    [TestMethod]
    public void GetTransaction_ShouldNotFindTransaction()
    {
      var context = new TestTransactionContext();
      context.Transactions.Add(new Transaction { TransactionId = 1, Description = "Demo1", TransactionAmount = 1.23M });
      context.Transactions.Add(new Transaction { TransactionId = 2, Description = "Demo2", TransactionAmount = 2.34M });
      context.Transactions.Add(new Transaction { TransactionId = 3, Description = "Demo3", TransactionAmount = 34.45M });
      context.Transactions.Add(new Transaction { TransactionId = 4, Description = "Demo4", TransactionAmount = 456.78M });
      var controller = new TransactionsController(context);

      try
      {
        var result = controller.GetTransaction(999);
      }
      catch (HttpResponseException ex)
      {
        Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest, "Transaction not found");
      }
    }


    [TestMethod]
    public void DeleteTransaction_ShouldDeleteTransactionWithSameId()
    {
      var context = new TestTransactionContext();
      context.Transactions.Add(new Transaction { TransactionId = 1, Description = "Demo1", TransactionAmount = 1.23M });
      context.Transactions.Add(new Transaction { TransactionId = 2, Description = "Demo2", TransactionAmount = 2.34M });
      context.Transactions.Add(new Transaction { TransactionId = 3, Description = "Demo3", TransactionAmount = 34.45M });
      context.Transactions.Add(new Transaction { TransactionId = 4, Description = "Demo4", TransactionAmount = 456.78M });
      var controller = new TransactionsController(context);

      var result = controller.DeleteTransaction(1);
      Assert.IsInstanceOfType(result, typeof(OkResult));
    }


    [TestMethod]
    public void DeleteTransaction_ShouldNotFindTransaction()
    {
      var context = new TestTransactionContext();
      context.Transactions.Add(new Transaction { TransactionId = 1, Description = "Demo1", TransactionAmount = 1.23M });
      context.Transactions.Add(new Transaction { TransactionId = 2, Description = "Demo2", TransactionAmount = 2.34M });
      context.Transactions.Add(new Transaction { TransactionId = 3, Description = "Demo3", TransactionAmount = 34.45M });
      context.Transactions.Add(new Transaction { TransactionId = 4, Description = "Demo4", TransactionAmount = 456.78M });
      var controller = new TransactionsController(context);

      try
      {
        var result = controller.DeleteTransaction(999);
      }
      catch (HttpResponseException ex)
      {
        Assert.AreEqual(ex.Response.StatusCode, HttpStatusCode.BadRequest, "Transaction not found");
      }
    }

    [TestMethod]
    public void PostTransaction_ShouldPostTransaction()
    {
      var context = new TestTransactionContext();
      context.Transactions.Add(new Transaction { TransactionId = 1, Description = "Demo1", TransactionAmount = 1.23M });
      context.Transactions.Add(new Transaction { TransactionId = 2, Description = "Demo2", TransactionAmount = 2.34M });
      context.Transactions.Add(new Transaction { TransactionId = 3, Description = "Demo3", TransactionAmount = 34.45M });
      context.Transactions.Add(new Transaction { TransactionId = 4, Description = "Demo4", TransactionAmount = 456.78M });
      var controller = new TransactionsController(context);

      var result = controller.PostTransaction(new Transaction { TransactionId = 5, Description = "Demo5", TransactionAmount = 5678.90M });
      var createdResult = result as CreatedAtRouteNegotiatedContentResult<Transaction>;

      Assert.IsNotNull(createdResult);
      Assert.AreEqual("DefaultApi", createdResult.RouteName);
      Assert.AreEqual(5, createdResult.Content.TransactionId);
    }
  }
}
