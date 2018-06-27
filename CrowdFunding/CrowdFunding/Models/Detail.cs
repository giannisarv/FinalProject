using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFunding.Models
{
    public partial class Detail
    {
        public long DetailId { get; set; }
        public long ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfUpdate { get; set; }

        public Project Project { get; set; }
    }
}
