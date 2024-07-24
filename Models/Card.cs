using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTGCollectionApp.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string CardName { get; set; } = string.Empty;

        [MaxLength(255)]
        public string ScryfallId { get; set; } = string.Empty;

        public int TcgId { get; set; }

        [MaxLength(255)]
        public string Set { get; set; } = string.Empty;

        [MaxLength(10)]
        public string SetCode { get; set; } = string.Empty;

        [MaxLength(10)]
        public string CollectorNumber { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Finish { get; set; } = string.Empty;

        [MaxLength(500)]
        public string PrintUri { get; set; } = string.Empty;

        [ForeignKey("Collection")]
        public int CollectionId { get; set; }
        public Collection Collection { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
