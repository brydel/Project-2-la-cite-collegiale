using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2_Brydel.Models
{
    public class Produit
    {
        [Key]
        public int ProduitId { get; set; }

        [Required]
        [StringLength(100)]  
        public string Nom { get; set; }

        [Required]
        [StringLength(250)]  
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]  
        [Range(0.01, 1000)]
        public decimal Prix { get; set; }

        [Required]
        [StringLength(255)]  
        public string ImageUrl { get; set; }

        public ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    }
}
