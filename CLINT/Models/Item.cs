using CLINT.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLINT.Models
{
    public class Store
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        // Foreign key to Item

        public Store? store { get; set; }
        [ForeignKey("StoreId")]
        public int? StoreId { get; set; }
    }
}
