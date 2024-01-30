using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain
{
    public class College
    {
        [Key]
        public int CollegeId { get; set; }

        [Required]
        [Display(Name ="College Name")]
        public string CollegeName { get; set; }

        [Display(Name ="About")]
        public string? CollegeDescription { get; set;}

        [Display(Name =("College Logo"))]
        public string? CollegeLogoUrl { get;set;}

        [Required]
        [Display(Name ="Name of Provost")]
        public string CollegeProvost { get; set; }

        [Required]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string CollegeEmail { get; set;}

        //Relationships
        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }
    }
}
