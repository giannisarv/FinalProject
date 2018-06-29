using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models
{
    public partial class Project
    {
        public Project()
        {
            Package = new HashSet<Package>();
            Update = new HashSet<Update>();
        }

        [Column("ID")]
        public long Id { get; set; }
        [Required]
        [Column("PersonID")]
        [StringLength(450)]
        public string PersonId { get; set; }
        [Column("CategoryID")]
        public long CategoryId { get; set; }
        [Column("HeroURL")]
        [StringLength(255)]
        [Url]
        public string HeroUrl { get; set; }
        [Required]
        [Column("Title")]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [DateValid]
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        [Range (0,100000)]
        public decimal Goal { get; set; }
        public decimal Progress { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Project")]
        public Category Category { get; set; }
        [ForeignKey("PersonId")]
        [InverseProperty("Project")]
        public AspNetUsers Person { get; set; }
        [InverseProperty("Project")]
        public ICollection<Package> Package { get; set; }
        [InverseProperty("Project")]
        public ICollection<Update> Update { get; set; }

        //public Package Name { get; set; }//Navigation property
        public class DateValid : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                value = (DateTime)value;

                if (DateTime.Now.AddYears(2).CompareTo(value) >= 0 && DateTime.Now.CompareTo(value) <= 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Date must be within the next two years!");
                }
            }
        }
    }
}
