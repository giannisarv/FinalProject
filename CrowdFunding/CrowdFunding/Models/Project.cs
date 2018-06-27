using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrowdFunding.Models
{
    public partial class Project
    {
        public Project()
        {
            Detail = new HashSet<Detail>();
            Package = new HashSet<Package>();
        }
        public long ProjectId { get; set; }
        [BindNever]
        public long PersonId { get; set; }
        public long CategoryId { get; set; }
        public string PictureUrl { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }

        public decimal Goal { get; set; }

        public Category Category { get; set; }
        public Person Person { get; set; }
        public ICollection<Detail> Detail { get; set; }
        public ICollection<Package> Package { get; set; }
    }
}
