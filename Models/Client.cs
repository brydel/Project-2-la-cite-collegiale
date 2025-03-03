using System.ComponentModel.DataAnnotations;

namespace Project2_Brydel.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [StringLength(50)]
        public string Prenom { get; set; }

        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Required]
        [StringLength(255)] 
        [DataType(DataType.EmailAddress)]
        public string Courriel { get; set; }

        [Required]
        [StringLength(20)] 
        [Phone]
        public string Telephone { get; set; }

        [Required]
        [StringLength(100)]
        public string Adresse { get; set; }

        
        public ICollection<Commande> Commandes { get; set; } = new List<Commande>();
    }
}
