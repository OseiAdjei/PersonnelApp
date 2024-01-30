using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }

        [Required]
        [Display(Name ="Faculty Name")]
        public string FacultyName { get; set; }

        [Display(Name ="About")]
        public string FacultyDescription { get; set; }

        public string? FacultyLogoUrl { get; set; }

        [Required]
        [Display(Name ="Dean of Faculty")]
        public string FacultyDean { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string FacultyEmail { get; set; }

        //Relationships

        public List<College> Colleges { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


    }
}
