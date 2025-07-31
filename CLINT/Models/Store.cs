
using System.ComponentModel.DataAnnotations;

namespace CLINT.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }


        public string? ItemName { get; set; }


        public string? ItemCode { get; set; }

        public bool IsFirstPurchase { get; set; }

        public int PurchaseAmount { get; set; }

        public int SalesAmount { get; set; }

        public int StockQuantity { get; set; }
    }
}
