using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFunding.Models
{
    public partial class Package
    {
        public Package()
        {
            PersonPackage = new HashSet<PersonPackage>();
        }

        public long PackageId { get; set; }
        public long ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public Project Project { get; set; }
        public ICollection<PersonPackage> PersonPackage { get; set; }
    }
}
