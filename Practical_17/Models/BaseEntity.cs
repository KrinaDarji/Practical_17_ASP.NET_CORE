using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_17.Models
{
    
        public abstract class BaseEntity
        {
            public int Id { get; set; }
            public DateTime DateCreated { get; set; }
            public DateTime DateModified { get; set; }
        }
    
}
