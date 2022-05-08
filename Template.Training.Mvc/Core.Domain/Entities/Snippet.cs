using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class Snippet : BaseEntity
    {
        public string? Tags { get; set; }
        public string? Description { get; set; }
        public string? Origin { get; set; }
        public string? Name { get; set; }
        public string? Language { get; set; }
    }
}
