using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name ="Department Name")]
        public string? DepartmentName { get; set; }

        [Display(Name ="Bio")]
        public string? DepartmentDescription { get; set; }

        [Display(Name="Profile Picture")]
        public string? DepartmentLogoUrl { get; set; }

        [Required]
        [Display(Name ="Head of Department")]
        public string? DepartmentHod { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string? DepartmentEmail { get; set; }

        //Relationships
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public List<Nsp>? Nsps { get; set; }
    }
}
