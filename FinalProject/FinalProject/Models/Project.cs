using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FinalProject.Controllers.ProjectsController;

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
        public string HeroUrl { get; set; }
        [Required]
        [Column("Title")]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DateValid]
        public DateTime Deadline { get; set; }
        [Required]
        [Range(0,1000000)]
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
        
    }
}
