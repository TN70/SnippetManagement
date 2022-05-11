using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Snippet : BaseEntity
    {
        public string? Description { get; set; }
        public string? Origin { get; set; }
        public string? Name { get; set; }
        public string? Text { get; set; }
        public string? Language { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
