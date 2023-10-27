using System.ComponentModel.DataAnnotations;

namespace CrudRestApi.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
