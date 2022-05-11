using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? Status { get; set; }
    }
}
