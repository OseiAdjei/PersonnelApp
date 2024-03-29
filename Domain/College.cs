﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain
{
    public class College
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CollegeId { get; set; }

        [Required]
        [Display(Name ="College Name")]
        public string? CollegeName { get; set; }

        [Display(Name ="About")]
        public string? CollegeDescription { get; set;}

        [Display(Name =("College Logo"))]
        public string? CollegeLogoUrl { get;set;}

        [Required]
        [Display(Name ="Name of Provost")]
        public string? CollegeProvost { get; set; }

        [Required]
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string? CollegeEmail { get; set;}

        //Relationships
        public List<Faculty>? Faculties { get; set;}
        public List<Nsp>? Nsps { get; set;}
    }
}
