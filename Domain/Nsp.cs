using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain
{
    public class Nsp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NspId { get; set; }

        [Required]
        [Display(Name ="NSS Number")]
        public string NspNumber { get; set; }

        [Display(Name ="Profile Picture")]
        public string? NspPicUrl { get; set; }

        [MaxLength(1000)]
        [Display(Name ="About")]
        public string? NspBio { get; set; }

        [MaxLength(100)]
        [Display(Name ="Name")]
        public string NspName { get; set; }

        [Required]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string NspEmail { get; set; }

        [Required]
        [Display(Name ="Phone Contact")]
        [MaxLength(9)]
        public string NspPhone { get; set; }
    }
}
