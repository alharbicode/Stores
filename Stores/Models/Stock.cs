using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        // Foreign key to Item

        public Store? Store { get; set; }
        [ForeignKey("StoreId")]
        public int? StoreId { get; set; }
    }
}
