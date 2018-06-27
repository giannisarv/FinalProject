using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFunding.Models
{
    public partial class PersonPackage
    {
        public long PackageId { get; set; }
        public long PersonId { get; set; }

        public Package Package { get; set; }
        public Person Person { get; set; }
    }
}
