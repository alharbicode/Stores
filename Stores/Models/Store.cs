using System.ComponentModel.DataAnnotations;

namespace Stores.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }
        public int Product_code { get; set; }
        public string? Product_name { get; set; }
        public int First_Time_purchase { get; set; }
        public int Item_purchase { get; set; }
        public int Item_sales { get; set; }
        public int Quantity_in_store { get; set; }
    }
}
