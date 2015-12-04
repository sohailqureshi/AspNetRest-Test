using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MoneyBox.Models
{
  [Table("ChatMessage")]
  public class Transaction
  {
    [Key]
    [Required]
    [ScaffoldColumn(false)]
    [Display(Name = "Id")]
    [HiddenInput(DisplayValue = false)]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long TransactionId { get; set; }

    [Required]
    [Display(Name = "Transaction Date")]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm}")]
    public DateTime TransactionDate { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    [Display(Name = "Amount")]
    public decimal TransactionAmount { get; set; }

    [Required]
    [HiddenInput(DisplayValue = false)]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm}")]
    public DateTime CreatedDate { get; set; }

    [Required]
    [HiddenInput(DisplayValue = false)]
    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm}")]
    public DateTime ModifiedDate { get; set; }

    [Required]
    [Display(Name = "Currency Code")]
    public string CurrencyCode { get; set; }

    [Required]
    [Display(Name = "Merchant Name")]
    public string Merchant { get; set; }

    public Transaction() {

      TransactionDate= DateTime.Now;
      CreatedDate = DateTime.Now;
      ModifiedDate = DateTime.Now;
      CurrencyCode = "GBP";
    }
  }
}
