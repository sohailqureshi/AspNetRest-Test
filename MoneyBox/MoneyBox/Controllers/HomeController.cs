using MoneyBox.Areas.Api.Controllers;
using MoneyBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Runtime.Serialization.Json;
using System.Web.Http.Controllers;

namespace MoneyBox.Controllers
{
  public class HomeController : Controller
  {
    TransactionContext db = new TransactionContext();

    public ActionResult Index()
    {
      ViewBag.Title = "Transaction Page";
      TransactionsController tc = new TransactionsController(db);
      var result = tc.GetAllTransactions() as OkNegotiatedContentResult<List<Transaction>>;
      return View(result.Content);
    }

    public ActionResult Create()
    {
      return View(new Transaction());
    }

    [HttpPost]
    public ActionResult Create(Transaction transaction)
    {
      TransactionsController tc = new TransactionsController(db);
      var result = tc.PostTransaction(transaction) as OkNegotiatedContentResult<Transaction>;
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      TransactionsController tc = new TransactionsController(db);
      var result = tc.DeleteTransaction(id);
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      TransactionsController tc = new TransactionsController(db);
      var result = tc.GetTransaction(id) as OkNegotiatedContentResult<Transaction>;
      return View(result.Content);
    }

    [HttpPost]
    public ActionResult Edit(Transaction transaction)
    {
      TransactionsController tc = new TransactionsController(db);
      var result = tc.PutTransaction(transaction.TransactionId, transaction) as OkNegotiatedContentResult<Transaction>;
      return RedirectToAction("Index");
    }
  }
}
