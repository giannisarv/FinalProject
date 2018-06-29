using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFunding.Models
{
    public partial class Detail
    {
        public long DetailId { get; set; }
        public long ProjectId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfUpdate { get; set; }

        public Project Project { get; set; }
    }
}
