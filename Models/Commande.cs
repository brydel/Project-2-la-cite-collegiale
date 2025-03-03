using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2_Brydel.Models
{
    public class Commande
    {
        [Key]
        public int CommandeId { get; set; }

        [Required]
        public int ProduitId { get; set; }

        [ForeignKey("ProduitId")]
        [Required]
        public Produit Produit { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string NomClient { get; set; }

        [Required]
        [StringLength(100)]
        public string PrenomClient { get; set; }

        [Required]
        [StringLength(255)]
        public string AdresseClient { get; set; }

        [Required]
        [StringLength(20)] 
        [Phone]
        public string TelephoneClient { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantite { get; set; }

        public DateTime DateCommande { get; set; } = DateTime.Now;
    }
}
