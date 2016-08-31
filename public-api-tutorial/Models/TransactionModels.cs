using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace public_api_tutorial.Models
{
    public class TransactionContainerViewModel
    {
        public TransactionSalesViewModel Sales { get; set; }
        public IEnumerable<CorrectionTransactionViewModel> Corrections { get; set; }
        public IEnumerable<PurchaseTransactionViewModel> Purchases { get; set; }
        public IEnumerable<TransferTransactionViewModel> Transfers { get; set; }
    }

    public class TransactionSalesViewModel
    {
        public IEnumerable<PosItemTransaction> SaleItems { get; set; }

        public IEnumerable<PosPaymentTransaction> SalePayment { get; set; }
    }
    public class PosItemTransaction
    {
        public decimal CostPrice { get; set; }
    }
    public class PosPaymentTransaction
    {

    }
    public class CorrectionTransactionViewModel
    {

    }
    public class PurchaseTransactionViewModel
    {
        public int SupplierOrderNumber { get; set; }

        public int MachineNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public int UserId { get; set; }
        public decimal SuggestedSalesPrice { get; set; }
        public decimal Discount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRateToLocalCurrency { get; set; }
        public decimal ExchangeRateToEUR { get; set; }
        public decimal CostPrice { get; set; }
        public int UniqueItemNumber { get; set; }
        public int SupplierId { get; set; }
        public int EAN { get; set; }
        public decimal WholeSaleCostPrice { get; set; }
        public int ShopId { get; set; }
        public int TransactionNumber { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public int TransactionType { get; set; }
        public int Quantity { get; set; }
        public int ItemGroupNumber { get; set; }
    }

    public class TransferTransactionViewModel
    {

    }

    public enum CorrectionTypeViewModel
    {
        Unknown = 0,
        Manual = 1,
        Status = 2
    }
}
