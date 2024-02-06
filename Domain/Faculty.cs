using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain
{
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacultyId { get; set; }

        [Required]
        [Display(Name ="Faculty Name")]
        public string FacultyName { get; set; }

        [Display(Name ="About")]
        public string FacultyDescription { get; set; }

        [Display(Name ="Logo")]
        public string? FacultyLogoUrl { get; set; }

        [Required]
        [Display(Name ="Dean of Faculty")]
        public string FacultyDean { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string FacultyEmail { get; set; }

        //Relationships
        public int CollegeId { get; set; }
        public College College { get; set; }
        public List<Nsp>? Nsps { get; set; }


    }
}
    