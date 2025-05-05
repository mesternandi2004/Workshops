using System.ComponentModel.DataAnnotations;

namespace Workshop_05.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string PayerName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Az összeg nem lehet negatív.")]
        public int Amount { get; set; }

        public bool IsPaid { get; set; }
    }
}
